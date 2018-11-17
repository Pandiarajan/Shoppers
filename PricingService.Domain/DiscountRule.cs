namespace PricingService.Domain
{
    public abstract class DiscountRule
    {
        public abstract bool IsApplicable(Product product);
        
        public virtual double CalculatePrice(double price, int quantity)
        {
            return price * quantity;
        }
    }
}