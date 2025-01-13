using FluentValidation;
using FluentValidation.AspNetCore;
using JoinToUs.Application.Mappings;
using JoinToUs.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToUs.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IJoinToUsService, JoinToUsService>();

            services.AddAutoMapper(typeof(CreateUserProfile));


            services.AddValidatorsFromAssemblyContaining<CreateUserProfile>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
