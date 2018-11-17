using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using ProductCatalogue.Config;
using ProductCatalogue.DataContract;
using ProductCatalogue.Domain;
using ProductCatalogue.Repository;

namespace ProductCatalogue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        // GET api/values
        [HttpGet, EnableQuery]
        public ActionResult<IQueryable<Product>> Get()
        {
            return Ok(productRepository.GetProducts().Convert());
        }
        
        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] ProductContract product)
        {
            var savedProduct = productRepository.Add(
                new Product(product.Name, product.Description, product.Quantity,
                new Category(product.Category),
                Domain.Unit.Get(product.Unit.ToString())));
            return Created($"api/odata/Products?$filter=id eq ", savedProduct.Id);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (productRepository.Delete(id))
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
