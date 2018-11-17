namespace PricingService.Domain
{
    public class Stationary30Percent : DiscountRule
    {
        public override bool IsApplicable(Product product)
        {
            return (string.Compare(product.Category, Category.Stationary, true) == 0);
        }

        public override double CalculatePrice(double price, int quantity)
        {
            return price * quantity * .7;
        }
    }
}