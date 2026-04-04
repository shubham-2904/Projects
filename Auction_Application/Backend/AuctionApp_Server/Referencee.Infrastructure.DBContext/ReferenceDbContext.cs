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
    public DbSet<AuctionItem> AuctionItem { get; set; }
    public DbSet<AuctionEvent> AuctionEvent { get; set; }
    public DbSet<AuctionParticipant> AuctionParticipant { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AuctionHouse>()
            .HasOne(ah => ah.User)
            .WithMany(u => u.AuctionHouses)
            .HasForeignKey(ah => ah.OwnerUserId)
                .HasConstraintName("FK_AuctionHouse_User_OwnerUserId")
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<AuctionItem>()
            .HasOne(ai => ai.AuctionHouse)
            .WithMany(ah => ah.AuctionItems)
            .HasForeignKey(ai => ai.AuctionHouseId)
                .HasConstraintName("FK_AuctionItem_AuctionHouse_AuctionHouseId")
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<AuctionEvent>()
            .HasOne(ae => ae.AuctionHouse)
            .WithMany(ah => ah.AuctionEvents)
            .HasForeignKey(ae => ae.ActionHouseId)
                .HasConstraintName("FK_AuctionEvent_AuctionHouse_ActionHouseId")
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<AuctionEvent>()
            .HasOne(ae => ae.Organizer)
            .WithMany(u => u.AuctionEvents)
            .HasForeignKey(ae => ae.OrganizerId)
                .HasConstraintName("FK_AuctionEvent_User_OrganizerId")
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<AuctionParticipant>()
            .HasOne(ap => ap.AuctionEvent)
            .WithMany(ae => ae.AuctionParticipants)
            .HasForeignKey(ah => ah.AuctionEventId)
                .HasConstraintName("FK_AuctionParticipant_AuctionEvent_AuctionEventId")
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<AuctionParticipant>()
            .HasOne(ap => ap.User)
            .WithMany(u => u.AuctionParticipants)
            .HasForeignKey(ah => ah.UserId)
                .HasConstraintName("FK_AuctionParticipant_User_UserId")
            .OnDelete(DeleteBehavior.NoAction);
    }
}
