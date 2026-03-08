using Microsoft.EntityFrameworkCore;
using Reference.Infrastructure.DBContext;

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
}
