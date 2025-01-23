using JoinToUs.Domain.Interfaces;
using JoinToUs.Infrastructure.Migrations;
using JoinToUs.Infrastructure.Presistence;
using JoinToUs.Infrastructure.Repositories;
using JoinToUs.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToUs.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("JoinToUs");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'JoinToUs' is not found.");
            }

            services.AddDbContext<JoinToUsDbContext>(options =>
                { options.UseSqlServer(connectionString);
                  options.EnableSensitiveDataLogging();
                });

            services.AddScoped<JoinToUsSeeder>();

            services.AddScoped<IJoinToUsRepository, JoinToUsRepository>();
        }
    }
}
