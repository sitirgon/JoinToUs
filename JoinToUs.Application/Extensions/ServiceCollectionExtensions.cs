using FluentValidation;
using FluentValidation.AspNetCore;
using JoinToUs.Application.JoinToUs.Command.CreateUserCommand;
using JoinToUs.Application.Mappings;
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
            services.AddMediatR(cfg => 
                cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly));

            services.AddAutoMapper(typeof(CreateUserProfile));


            services.AddValidatorsFromAssemblyContaining<CreateUserProfile>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
