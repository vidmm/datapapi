using Microsoft.EntityFrameworkCore;

namespace DataPapi.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DimProduct> DimProducts { get; set; } = null!;
        public virtual DbSet<FactOnlineSale> FactOnlineSales { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DimProduct>(eb => eb.HasKey(x => x.ProductKey));
            modelBuilder.Entity<FactOnlineSale>(eb => eb.HasKey(x => x.OnlineSalesKey));
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
