namespace PricingService.Domain
{
    public class NoDiscount : DiscountRule
    {
        public override bool IsApplicable(Product product)
        {
            return true;
        }
    }
}