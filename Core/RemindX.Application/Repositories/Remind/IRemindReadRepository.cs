using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RemindX.Application.Repositories.Remind
{
    public interface IRemindReadRepository
    {
        IQueryable<Domain.Entities.Remind> GetAll();
        IQueryable<Domain.Entities.Remind> GetWhere(Expression<Func<Domain.Entities.Remind, bool>> method);

        Task<Domain.Entities.Remind> GetSingleAsync(Expression<Func<Domain.Entities.Remind, bool>> method);

        Task<Domain.Entities.Remind> GetByIdAsync(int id);
    }
}
