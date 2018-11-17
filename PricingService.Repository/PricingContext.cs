using Microsoft.EntityFrameworkCore;
using PricingService.Domain;

namespace PricingService.Repository
{
    public class PricingContext : DbContext
    {
        public PricingContext(DbContextOptions<PricingContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PriceDetail>().HasKey(e => e.ProductId);

            modelBuilder.Entity<PriceDetail>().HasData(
                new PriceDetail { ProductId = 1, Price = 500 },
                new PriceDetail { ProductId = 2, Price = 1500 },
                new PriceDetail { ProductId = 3, Price = 700 },
                new PriceDetail { ProductId = 4, Price = 1700 },
                new PriceDetail { ProductId = 5, Price = 2700 },
                new PriceDetail { ProductId = 6, Price = 1000 });
        }
        public DbSet<PriceDetail> PriceDetails { get; set; }
    }
}
