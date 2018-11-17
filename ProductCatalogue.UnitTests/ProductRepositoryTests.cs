using Microsoft.EntityFrameworkCore;
using ProductCatalogue.Domain;
using ProductCatalogue.Repository;
using System.Linq;
using Xunit;

namespace ProductCatalogue.UnitTests
{
    public class ProductRepositoryTests
    {
        IProductRepository repository;
        ApiContext context;

        public ProductRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase(databaseName: "ProductsDatabase")
                .Options;
            context = new ApiContext(options);            
            repository = new ProductRepository(context);
        }

        [Fact]
        public void AddProductShould_AddCategories_IfNotPresent()
        {
            if (!context.Units.Any())
            {
                context.Units.Add(Unit.Descrete);                
                context.SaveChanges();
            }
            string category = "Stationary";
            repository.Add(new Product("Pen", "New Pen", 15, new Category(category), Unit.Descrete));
            Assert.True(context.Categories.Any(c => c.Name == category));
        }

        [Fact]
        public void AddProductShould_IncreaseCount_IfSameProductExists()
        {
            if (!context.Units.Any())
            {
                context.Units.Add(Unit.Gram);
                context.SaveChanges();
            }

            string category = "Clothes";
            var product = new Product("Sugar", "New Sugar Brand", 25, new Category(category), Unit.Gram);
            
            repository.Add(product);
            repository.Add(product);
            Assert.Equal(50, context.Products.First(p => p.Name == "Sugar").Quantity);
        }
    }
}
