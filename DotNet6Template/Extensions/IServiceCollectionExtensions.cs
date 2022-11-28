using Template.Domain.Interfaces;
using Template.Infrastructure;
using Template.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Template.Domain.Users;
using Template.Services.Users;

namespace DotNet6Template.API.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure DbContext with Scoped lifetime
            services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("ManagementConnection"));
                    options.UseLazyLoadingProxies();
                }
            );

            services.AddScoped<Func<AppDbContext>>((provider) => () => provider.GetService<AppDbContext>());
            services.AddScoped<DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IUserRepository, UserRepository>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<UserService>()
                .AddScoped<UserService>()
                .AddScoped<UserService>()
                .AddScoped<UserService>();
        }
    }
}
