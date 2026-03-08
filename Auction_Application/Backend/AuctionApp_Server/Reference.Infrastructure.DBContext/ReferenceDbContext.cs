using Microsoft.EntityFrameworkCore;

namespace Reference.Infrastructure.DBContext;

/// <summary>
/// Contain the DbContext and model creating code for reference
/// </summary>
public sealed class ReferenceDbContext : DbContext
{
    public ReferenceDbContext(DbContextOptions<ReferenceDbContext> options) 
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
