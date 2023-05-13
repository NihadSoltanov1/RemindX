using Microsoft.EntityFrameworkCore;
using RemindX.Application.Repositories;
using RemindX.Domain.Entities.Common;
using RemindX.Infrastructure.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RemindX.Infrastructure.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly RemindXDbContext _context;

        public ReadRepository(RemindXDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table =>_context.Set<T>();

        public IQueryable<T> GetAll() => Table;


        public async Task<T> GetByIdAsync(int id) => await Table.Where(x => x.Id == id).FirstOrDefaultAsync();
        

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method) => await Table.FirstOrDefaultAsync(method);


        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method) => Table.Where(method);

    }
}
