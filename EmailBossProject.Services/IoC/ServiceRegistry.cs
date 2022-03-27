using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailBossProject.Services.IoC
{
    public static class ServiceRegistry
    {
        public static void AddServiceRegistry(this IServiceCollection services)
        {
            services.AddTransient<IBossService, BossService>();
            /*services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddSingleton<IEmailService, EmailService>();*/
            services.AddTransient<IExample, Example>();
        }
    }
}
