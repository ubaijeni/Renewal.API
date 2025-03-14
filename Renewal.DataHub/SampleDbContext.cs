using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Renewal.DataHub.Models.Domain;

namespace Renewal.DataHub
{
    public class SampleDbContext:DbContext
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<RenewalValue> Renewalset { get; set; }
        public DbSet<TransactionDetails> Trans { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
