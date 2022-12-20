using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Data.Context;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Config
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigDependency(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperConfig));
            services.AddScoped<DbContext,appDbContext>();

            services.AddScoped<IInputRelationsService, InputRelationsRepository>();
            services.AddScoped<ICustomerService, CustomerRepository>();            
           

            services.AddApiVersioning (options =>
            {

                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });


            return services; 

        }

    }
}
