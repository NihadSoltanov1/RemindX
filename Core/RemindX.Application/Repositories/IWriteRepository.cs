using RemindX.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemindX.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T:BaseEntity
    {
        Task<bool> AddAsync(T model);
        bool Remove(T model);
        Task<bool> RemoveAsync(string id);
        bool Update(T model);
        Task<int> SaveChangesAsync();
    }
}
