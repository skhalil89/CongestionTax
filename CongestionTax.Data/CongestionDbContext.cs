using CongestionTax.Domain;
using Microsoft.EntityFrameworkCore;

namespace CongestionTax.Data
{
    public class CongestionDbContext : DbContext
    {
        public CongestionDbContext()
        {

        }

        public CongestionDbContext(DbContextOptions<CongestionDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\sql2022;Initial Catalog=CongestionDb; Integrated Security=false;user id=sa;password=P@ssw0rd;Encrypt=False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Seed();
        }

        public DbSet<TaxRate> TaxRates { get; set; }
        public DbSet<Exemption> Exemption { get; set; }

        public override int SaveChanges()
        {
            ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added).ToList()
                .ForEach(x => x.Property("CreatedDate").CurrentValue = DateTimeOffset.Now);
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added).ToList()
                .ForEach(x => x.Property("CreatedDate").CurrentValue = DateTimeOffset.Now);
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
