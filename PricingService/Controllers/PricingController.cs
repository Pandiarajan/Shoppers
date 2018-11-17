using System;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PricingService.Domain;
using PricingService.Model;
using PricingService.Repository;

namespace PricingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        private readonly PricingContext pricingContext;
        private readonly IPricingCalculator calculator;
        private readonly IConfiguration config;

        public PricingController(PricingContext pricingContext, IPricingCalculator calculator, IConfiguration config)
        {
            this.pricingContext = pricingContext;
            this.calculator = calculator;
            this.config = config;
        }

        [HttpGet]
        public ActionResult<string> Get() => Ok("Success");

        // GET api/values/5
        [HttpGet("{productId}/{quantity}")]
        public ActionResult<double> Get(int productId, int quantity)
        {
            double finalPrice = 0.0;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(config.GetValue<string>("ProductCatalogueUrl"));
                var url = "Products?$filter=id eq " + productId;
                var responseTask = client.GetAsync(url);
                responseTask.Wait();
                Product product = null;
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync(); //<ODataModel>();
                    readTask.Wait();
                    product = JsonConvert.DeserializeObject<ODataModel>(readTask.Result).Value[0]; //.Products[0];
                }
                var priceDetail = pricingContext.PriceDetails.FirstOrDefault(p => p.ProductId == productId);
                
                if (priceDetail != null && product != null)
                {
                    finalPrice = calculator.Calculate(product, priceDetail.Price, quantity);
                }
            }
            return Ok(finalPrice);
        }
    }
}
