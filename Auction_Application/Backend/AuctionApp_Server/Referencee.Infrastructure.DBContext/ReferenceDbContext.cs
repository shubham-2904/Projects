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
    public DbSet<AuctionHouse> AuctionHouse { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuctionHouse>()
            .HasOne(ah => ah.User)
            .WithMany(u => u.AuctionHouses)
            .HasForeignKey(ah => ah.OwnerUserId)
                .HasConstraintName("FK_AuctionHouse_User_OwnerUserId");

        base.OnModelCreating(modelBuilder);
    }
}
