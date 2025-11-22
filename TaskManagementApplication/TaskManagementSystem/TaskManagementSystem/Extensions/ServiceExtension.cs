using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;
using RepositoryManager.Contract;
using Service;
using ServiceContracts;

namespace TaskManagementSystem.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
        }

        public static void ConfigureRepositaryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager.Repository.RepositoryManager>();
        }

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskManagerContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"))
            );
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
    }
}
