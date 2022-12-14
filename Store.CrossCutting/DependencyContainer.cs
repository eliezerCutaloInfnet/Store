using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Store.Application._shared;
using Store.Application.AppServices;
using Store.Application.AutoMapper;
using Store.Application.Interfaces;
using Store.Application.Notifications;
using Store.Domain._shared;
using Store.Domain.Interface;
using Store.Infra.Data._shared;
using Store.Infra.Data.Context;
using Store.Infra.Data.Repositories;

namespace Store.Infra.CrossCutting
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
            services.AddScoped<INotifier, Notifier>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<GlobalExceptionHandlerFilter>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILoginAppService, LoginAppService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductAppService, ProductAppService>();

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookAppService, BookAppService>();

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