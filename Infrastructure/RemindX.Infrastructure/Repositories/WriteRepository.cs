using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RemindX.Application.Repositories;
using RemindX.Domain.Entities.Common;
using RemindX.Infrastructure.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemindX.Infrastructure.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {

        private readonly RemindXDbContext _context;

        public WriteRepository(RemindXDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
          EntityEntry<T> entityState =   await Table.AddAsync(model);
            return entityState.State == EntityState.Added;
        }

        public bool Remove(T model)
        {
           EntityEntry<T> entityState =  Table.Remove(model);
            return entityState.State == EntityState.Deleted; 
        }

        public async Task<bool> RemoveAsync(int id)
        {
           T model = await  Table.FirstOrDefaultAsync(x => x.Id == id);
            return Remove(model);
        }
        public bool Update(T model)
        {
            EntityEntry<T> entityState = Table.Update(model);
            return entityState.State == EntityState.Modified;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
