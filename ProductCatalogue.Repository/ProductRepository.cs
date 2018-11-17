using Microsoft.EntityFrameworkCore;
using ProductCatalogue.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ProductCatalogue.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiContext _apiContext;

        public ProductRepository(ApiContext apiContext)
        {
            _apiContext = apiContext;
        }

        public Product GetProduct(int id)
        {
            return _apiContext.Products.Include(p => p.Category).Include(p => p.Unit).FirstOrDefault(p => p.Id == id);
        }
        public IEnumerable<Product> GetProducts()
        {
            return _apiContext.Products.Include(p => p.Category).Include(p => p.Unit);
        }

        public Product Add(Product product)
        {
            var category = _apiContext.Categories.FirstOrDefault(c => c.Name == product.Category.Name);
            if (category == null)
            {
                _apiContext.Categories.Add(product.Category);
                _apiContext.SaveChanges();
            }
            else
            {
                product.Category = category;
                product.CategoryId = category.Id;
            }
            var existing = _apiContext.Products.FirstOrDefault(p => p.Name == product.Name && p.Description == product.Description);
            if (existing != null)            
                existing.Quantity += product.Quantity;            
            else
                _apiContext.Products.Add(product);

            _apiContext.SaveChanges();
            return existing;
        }

        public bool Delete(int id)
        {
            var product = _apiContext.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _apiContext.Products.Remove(product);
                _apiContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
