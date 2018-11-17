namespace PricingService.Domain
{
    public interface IPricingCalculator
    {
        double Calculate(Product product, double price, int quantity);
    }
}
