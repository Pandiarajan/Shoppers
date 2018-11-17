using Microsoft.Extensions.DependencyInjection;
using ProductCatalogue.DataContract;
using ProductCatalogue.Domain;
using ProductCatalogue.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ProductCatalogue.Config
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            return services
                .AddScoped<ApiContext, ApiContext>()
                .AddScoped<IProductRepository, ProductRepository>();                
        }
        public static IQueryable<ProductContract> Convert(this IEnumerable<Product> products)
        {
            return products.Select(p => new ProductContract { Id = p.Id, Name = p.Name, Description = p.Description, Quantity = p.Quantity, Category = p.Category.Name, Unit = (DataContract.Unit)p.Unit.Id }).AsQueryable();
        }
        public static ProductContract Convert(this Product product)
        {
            if (product == null)
                return null;
            return new ProductContract { Id = product.Id, Name = product.Name, Description = product.Description, Quantity = product.Quantity, Category = product.Category.Name, Unit = (DataContract.Unit)product.Unit.Id };
        }
    }
}
