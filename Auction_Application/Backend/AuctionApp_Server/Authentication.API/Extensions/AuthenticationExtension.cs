using AuctionApp.Utilities;
using Authentication.Infrastructure.DBContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
    /// Adds token config json to the configuration pipeline
    /// </summary>
    /// <param name="configurationManager"></param>
    public static void AddTokenConfigJson(this ConfigurationManager configurationManager)
    {
        string tokensConfigJsonFilePath = Path.Combine(AppContext.BaseDirectory, "tokens.config.json");
        configurationManager.AddJsonFile(tokensConfigJsonFilePath, false, true);
    }

    /// <summary>
    /// Adds Utility class to service collection pipeline
    /// </summary>
    /// <param name="services"></param>
    public static void AddUtilityRegistration(this IServiceCollection services)
    {
        services.AddSingleton<AuctionApp.Utilities.Utility>();
    }

    /// <summary>
    /// Adds Sql Database to the pipeline
    /// </summary>
    /// <param name="services"></param>
    /// <param name="config"></param>
    public static void AddSqlDb(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AuthenticationDbContext>(options =>
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

    /// <summary>
    /// Add Jwt Token Authentication to the pipeline
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddJwtTokenAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        IConfigurationSection jwtSettings = configuration.GetSection("Jwt");

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false,
                    RequireExpirationTime = false,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = string.Empty,
                    ValidAudience = string.Empty,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!))
                };
            });
    }
}
