using Microsoft.EntityFrameworkCore;
using RemindX.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemindX.Infrastructure.Concrete
{
    public class RemindXDbContext : DbContext
    {
        public RemindXDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Remind> Reminds { get; set; }
    }
}
