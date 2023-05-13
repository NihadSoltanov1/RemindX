using RemindX.Application.Repositories.Remind;
using RemindX.Infrastructure.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemindX.Infrastructure.Repositories.Remind
{
    public class RemindWriteRepository : WriteRepository<Domain.Entities.Remind>, IWriteRemindRepository
    {
        public RemindWriteRepository(RemindXDbContext context) : base(context)
        {
        }
    }
}
