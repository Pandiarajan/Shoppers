using ProductCatalogue.Domain;
using System.Collections.Generic;

namespace ProductCatalogue.Repository
{
    public interface IProductRepository
    {
        Product GetProduct(int id);
        IEnumerable<Product> GetProducts();
        Product Add(Product product);
        bool Delete(int id);
    }
}
