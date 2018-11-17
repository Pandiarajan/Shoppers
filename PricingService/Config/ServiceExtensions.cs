using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PricingService.Domain;
using PricingService.Repository;
namespace ProductCatalogue.Config
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration config)
        {
            return services
                .AddScoped<PricingContext, PricingContext>()
                .AddScoped<IPricingCalculator, PricingCalculator>()
                .AddSingleton(config);
        }
    }
}
