using Contract.Services;
using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;
using Services;

namespace Person_Api.Extensions {
  public static class ServiceExtensions {

    // Configure Cors Plolicy
    public static void ConfigureCors(this IServiceCollection services) {
      services.AddCors(option => {
        option.AddPolicy("CorsPolicy", policy => {
          policy.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod();
        });
      });
    }

    // Configure Logger Service
    public static void ConfigureLoggerService(this IServiceCollection services) {
      services.AddSingleton<ILoggerManager, LoggerManager>();
    }

    // Configure Sql DataBase
    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) {
      services.AddDbContext<RepositoryContext>(opts => {
        opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"));
      });
    }

    // Configure Repository Manager
    public static void ConfigureRepositoryManager(this IServiceCollection services) {
      services.AddScoped<IRepositoryManager, RepositoryManager>();
    }

    // Configure Service Manager
    public static void ConfigureServiceManager(this IServiceCollection services) {
      services.AddScoped<IServiceManager, ServiceManager>();
    }
  }
}
