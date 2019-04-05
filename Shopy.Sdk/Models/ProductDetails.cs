using System.Collections.Generic;

namespace Shopy.Sdk.Models
{
    public class ProductDetails
    {
        public Product Product { get; set; }

        public IEnumerable<Product> RelatedProducts { get; set; }
    }
}
