using RemindX.Application.Repositories.Remind;
using RemindX.Infrastructure.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemindX.Infrastructure.Repositories.Remind
{
    public class RemindReadRepository : ReadRepository<Domain.Entities.Remind>, IReadRemindRepository
    {
        public RemindReadRepository(RemindXDbContext context) : base(context)
        {
        }
    }
}
