using System.Collections.Generic;
using System.Linq;

namespace PricingService.Domain
{
    public class PricingCalculator : IPricingCalculator
    {
        private readonly List<DiscountRule> _discountRules;

        public PricingCalculator()
        {
            _discountRules = new List<DiscountRule>();
            _discountRules.Add(new Stationary30Percent());
            _discountRules.Add(new NoDiscount());
        }

        public double Calculate(Product product, double price, int quantity)
        {
            return _discountRules.First(r => r.IsApplicable(product)).CalculatePrice(price, quantity);
        }
    }
}
