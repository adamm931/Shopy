using System;

namespace Shopy.Sdk.Models
{
    public class ProductDetails
    {
        public Guid ProductUid { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public Product[] RelatedProducts { get; set; }

        public SizeType[] Sizes { get; set; }
    }
}
