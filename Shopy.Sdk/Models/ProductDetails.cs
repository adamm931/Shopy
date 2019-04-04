using System;
using System.Collections.Generic;

namespace Shopy.Sdk.Models
{
    public class ProductDetails
    {
        public Guid Uid { get; set; }

        public long ProductId { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public BrandType Brand { get; set; }

        public IEnumerable<SizeType> Sizes { get; set; }

        public IEnumerable<Product> RelatedProducts { get; set; }
    }
}
