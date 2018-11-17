namespace PricingService.Domain
{
    public class Category
    {
        public const string Stationary = "Stationary";
        public const string Electronics = "Electronics";
        public const string Clothes = "Clothes";

        public string Name { get; internal set; }
    }
}