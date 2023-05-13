using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RemindX.Application.Repositories.Remind
{
    public interface IRemindWriteRepository 
    {
        Task<bool> AddAsync(Domain.Entities.Remind model);
        bool Remove(Domain.Entities.Remind model);

        Task<bool> RemoveAsync(int id);

        bool Update(Domain.Entities.Remind model);
        Task<int> SaveChangeAsync();
        
    }
}
