using AuctionAp.Utilities;
using Authentication.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Authentication.API.Extensions;

public static class AuthenticationExtension
{
    /// <summary>
    /// Adds utilities config json to the configuration pipeline
    /// </summary>
    /// <param name="configurationManager"></param>
    public static void AddUtiliesConfigJson(this ConfigurationManager configurationManager)
    {
        string utilitesConfigJsonFilePath = Path.Combine(AppContext.BaseDirectory, "utilities.config.json");
        configurationManager.AddJsonFile(utilitesConfigJsonFilePath, false, true);
    }

    /// <summary>
    /// Adds Utility class to service collection pipeline
    /// </summary>
    /// <param name="services"></param>
    public static void AddUtilityRegistration(this IServiceCollection services)
    {
        services.AddSingleton<Utility>();
    }

    /// <summary>
    /// Adds Sql Database to the pipeline
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    public static void AddSqlDb(this IServiceCollection services, IConfiguration config)
    {
        services.AddPooledDbContextFactory<AuthenticationDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("sqlConnection"))
        );
    }

    /// <summary>
    /// Adds authentication services to the pipeline
    /// </summary>
    /// <param name="services"></param>
    public static void AddAuthenticationService(this IServiceCollection services)
    {
        
    }
}
