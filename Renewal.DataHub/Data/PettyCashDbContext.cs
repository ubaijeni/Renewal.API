using Microsoft.EntityFrameworkCore;
using Renewal.DataHub.Models.Domain;
using Renewal.DataHub.Models.Domain;

namespace Renewal.DataHub
{
    public class PettyCashDbContext:DbContext
    {
        public PettyCashDbContext(DbContextOptions<PettyCashDbContext> options) : base(options) { }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<PettyCashTransaction> PettyCashTransaction { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
}
