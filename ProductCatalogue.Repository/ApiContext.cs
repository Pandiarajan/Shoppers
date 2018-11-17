using Microsoft.EntityFrameworkCore;
using ProductCatalogue.Domain;

namespace ProductCatalogue.Repository
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unit>().HasKey(e => e.Id);
            modelBuilder.Entity<Category>().Property(e => e.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Unit>().HasData(
                Unit.Descrete,
                Unit.Gram,
                Unit.MilliLiter);

            modelBuilder.Entity<Category>().HasData(
                new Category(1, "Stationary"),
                new Category(2, "Clothes"),
                new Category(3, "Electronics"));

            modelBuilder.Entity<Product>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>().HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Product>().HasOne(p => p.Unit).WithMany(c => c.Products).HasForeignKey(p => p.UnitId);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Parker Pen", Quantity = 5, CategoryId = 1, Description = "Imported Parker Pen", UnitId = Unit.Descrete.Id, },
                new Product { Id = 2, Name = "Mens Shirt", Quantity = 12, CategoryId = 2, Description = "Branded Shirt", UnitId = Unit.Descrete.Id, },
                new Product { Id = 3, Name = "Mens Trouser", Quantity = 25, CategoryId = 2, Description = "Brand B Trouser", UnitId = Unit.Descrete.Id, },
                new Product { Id = 4, Name = "TV", Quantity = 10, CategoryId = 3, Description = "LED TV", UnitId = Unit.Descrete.Id, }
                );
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
