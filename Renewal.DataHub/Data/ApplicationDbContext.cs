using Microsoft.EntityFrameworkCore;
using Renewal.DataHub.Models.Domain;

namespace Renewal.DataHub.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<PODetail> PODetails { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<PODetail>(entity =>
        {
            entity.HasKey(e => e.POId);
            
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime");

            entity.Property(e => e.UpdatedDateTime)
                .HasColumnType("datetime");
        });
        modelBuilder.Entity<Category>( entity =>
        {
            entity.HasKey(e => e.CategoryId);
            
            entity.Property(e => e.CreatedDate)
                .HasColumnType("date");

            entity.Property(e => e.UpdatedDate)
                .HasColumnType("date");
        });
    }
}