using System.Collections.Generic;

namespace Shopy.Core.Models
{
    public class ProductDetails
    {
        public Product Product { get; set; }

        public IEnumerable<Product> RelatedProducts { get; set; }
    }
}