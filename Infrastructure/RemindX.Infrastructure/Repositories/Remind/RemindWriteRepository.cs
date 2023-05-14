using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RemindX.Application.Abstractions.Services;
using RemindX.Application.Repositories.Remind;
using RemindX.Infrastructure.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RemindX.Infrastructure.Repositories.Remind
{
    public class RemindWriteRepository : IRemindWriteRepository
    {
        private readonly RemindXDbContext _context;
        private readonly ISenderService _senderService;
        public RemindWriteRepository(RemindXDbContext context, ISenderService senderService)
        {
            _context = context;
            _senderService = senderService;
        }
        public DbSet<Domain.Entities.Remind> Table => _context.Set<Domain.Entities.Remind>();
         public async Task<bool> AddAsync(Domain.Entities.Remind model)
        {
            switch (model.MetodType)
            {
                case Domain.Enums.Method.Email:
                    _senderService.RemindByEmail(model.Receiver, model.Content, model.RemindDate);
                    break;
                case Domain.Enums.Method.Telegram:
                    _senderService.RemingByTelegram(model.Receiver, model.Content, model.RemindDate);
                    break;
            }
            EntityEntry<Domain.Entities.Remind> entityState = await Table.AddAsync(model);
            return entityState.State == EntityState.Added;
        }

        public bool Remove(Domain.Entities.Remind model)
        {
            EntityEntry<Domain.Entities.Remind> entityState = Table.Remove(model);
            return entityState.State == EntityState.Deleted;
        }

        public async  Task<bool> RemoveAsync(int id)
        {
            Domain.Entities.Remind model = await Table.FirstOrDefaultAsync(x => x.Id == id);
            return Remove(model);
        }

        

        public bool Update(Domain.Entities.Remind model)
        {
            EntityEntry<Domain.Entities.Remind> entityState = Table.Update(model);
            return entityState.State == EntityState.Modified;
        }
        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
