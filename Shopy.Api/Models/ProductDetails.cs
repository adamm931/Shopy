using System.Collections.Generic;

namespace Shopy.Api.Models
{
    public class ProductDetails : Product
    {
        public List<Product> OtherSizesProducts { get; set; }

        public List<Product> RelatedProducts { get; set; }
    }
}