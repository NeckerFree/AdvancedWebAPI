using AWA.DataAccess;
using AWA.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWA.Repository
{
    public static class DependencyInjection 
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AdventureWorksContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IEmailAddressRepository, EmailAddressRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
    
}
