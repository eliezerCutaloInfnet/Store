﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Store.Domain._shared;
using Store.Infra.Data._shared;
using Store.Infra.Data.Context;
using Store.Application.AutoMapper;

namespace Store.Infra.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            const string root = "Store";
            var scanAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                                      .Where(w => w.FullName.StartsWith(root));

            services.AddAutoMapper((sp, cfg) =>
            {
                cfg.AddProfile(new ServiceProfile());
            }, scanAssemblies, ServiceLifetime.Transient);

            return services;
        }
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }

        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            return services;
        }
    }
}