using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using ProductCatalogue.DataContract;

namespace ProductCatalogue.Config
{
    public class ODataConfig
    {
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<ProductContract>("Products");
            return builder.GetEdmModel();
        }
    }
}
