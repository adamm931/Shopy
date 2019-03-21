using System;

namespace Shopy.SDK.Models.Products
{
    public class EditProduct
    {
        public Guid Uid { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string SizeType { get; set; }

        public string BrandType { get; set; }
    }
}
