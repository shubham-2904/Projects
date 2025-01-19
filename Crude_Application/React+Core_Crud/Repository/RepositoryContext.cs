using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository {
    public class RepositoryContext : DbContext {
        public RepositoryContext(DbContextOptions options) : base(options) {

        }

        DbSet<Person>? Person { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Person>(entity => {
                entity.ToTable("PERSON");

                entity.HasKey(p => p.Id)
                .HasName("PK_PERSON_Id");

                entity.Property(e => e.First_Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Last_Name)
                    .IsRequired()
                    .HasMaxLength(250);
            });
        }
    }
}
