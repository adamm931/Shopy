using System.Collections.Generic;

namespace Shopy.Core.Models
{
    public class ProductDetailsResponse
    {
        public ProductReponse Product { get; set; }

        public IEnumerable<ProductReponse> RelatedProducts { get; set; }
    }
}