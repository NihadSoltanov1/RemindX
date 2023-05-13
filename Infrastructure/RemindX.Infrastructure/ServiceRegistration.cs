using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RemindX.Application.Abstractions.Services;
using RemindX.Application.Repositories.Remind;
using RemindX.Infrastructure.Concrete;
using RemindX.Infrastructure.Repositories.Remind;
using RemindX.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemindX.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RemindXDbContext>(option => option.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));
            services.AddScoped<IRemindReadRepository,RemindReadRepository>();
            services.AddScoped<IRemindWriteRepository,RemindWriteRepository>();
            services.AddScoped<ISenderService, SenderService>();
            
        }
    }
}
