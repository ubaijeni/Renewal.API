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
    public DbSet<Branch> Branches { get; set; }
    public DbSet<PettyCashTransaction> PettyCashTransaction { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<RenewalValue> Renewalset { get; set; }
    public DbSet<TransactionDetails> Trans { get; set; }

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
        modelBuilder.Entity<Branch>()
                .HasKey(b => b.BranchID);

        modelBuilder.Entity<PettyCashTransaction>()
            .HasKey(p => p.TransactionID);

        modelBuilder.Entity<PettyCashTransaction>()
            .HasOne(p => p.Branch)
            .WithMany(b => b.PettyCashTransaction)
            .HasForeignKey(p => p.BranchID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}