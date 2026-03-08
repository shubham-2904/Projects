using LoggerService;
using Microsoft.EntityFrameworkCore;
using Reference.Infrastructure.DBContext;
using ReferenceRepositoryManager;
using ReferenceServices.Services;
using ReferenceServices.ServicesInterfaces;

namespace Auction.Reference.API.Extensions;

public static class ReferenceExtension
{
    /// <summary>
    /// Adds Sql Database to the pipeline
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    public static void AddSqlDb(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ReferenceDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("sqlConnection"))
        );
    }

    /// <summary>
    /// Add logger to the pipeline
    /// </summary>
    /// <param name="services"></param>
    public static void AddLoggerManager(this IServiceCollection services)
    {
        services.AddSingleton< ILoggerManager, LoggerManager>();
    }

    /// <summary>
    /// Adding Repository Manager to the pipeline
    /// </summary>
    /// <param name="services"></param>
    public static void AddRepositoryManager(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryManager, RepositoryManager>();
    }

    /// <summary>
    /// Adding Service Manager to the pipeline
    /// </summary>
    /// <param name="services"></param>
    public static void AddServiceManager(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();
    }
}
