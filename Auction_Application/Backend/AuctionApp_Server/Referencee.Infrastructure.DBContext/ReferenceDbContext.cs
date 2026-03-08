using Microsoft.EntityFrameworkCore;
using Reference.Domain.Model;

namespace Reference.Infrastructure.DBContext;

public class ReferenceDbContext : DbContext
{
    public ReferenceDbContext(DbContextOptions<ReferenceDbContext> options)
        : base(options)
    {
        
    }

    // DbSets
    public DbSet<User> User { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
