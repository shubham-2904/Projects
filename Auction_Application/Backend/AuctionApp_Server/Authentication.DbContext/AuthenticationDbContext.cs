using Authentication.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Infrastructure.DBContext;

/// <summary>
/// Contain the DbContext and model creating code for authentication
/// </summary>
public class AuthenticationDbContext : DbContext
{
    public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options)
        : base(options)
    {
        
    }

    // DbSets
    public DbSet<UserLogin> UserLogin { get; set; }
    public DbSet<LoginStatus> LoginStatus { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoginStatus>()
            .HasOne(ls => ls.Login)
            .WithMany(ul => ul.LoginStatuses)
            .HasForeignKey(ls => ls.LoginId)
                .HasConstraintName("FK_LoginStatus_UserLogin_LoginId");
        

        base.OnModelCreating(modelBuilder);
    }
}
