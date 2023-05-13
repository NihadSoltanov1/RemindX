using Microsoft.EntityFrameworkCore;
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
    public class RemindReadRepository : IRemindReadRepository
    {
        private readonly RemindXDbContext _context;

        public RemindReadRepository(RemindXDbContext context)
        {
            _context = context;
        }


        public  IQueryable<Domain.Entities.Remind> GetAll()
        {
            return _context.Reminds.AsQueryable();
        }

        public async Task<Domain.Entities.Remind> GetByIdAsync(int id) => await _context.Reminds.Where(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<Domain.Entities.Remind> GetSingleAsync(Expression<Func<Domain.Entities.Remind, bool>> method) => await _context.Reminds.FirstOrDefaultAsync(method);

        public IQueryable<Domain.Entities.Remind> GetWhere(Expression<Func<Domain.Entities.Remind, bool>> method) => _context.Reminds.Where(method);
    }
}
