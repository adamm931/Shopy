
using Shopy.SDK.ApiModels.Categories;
using System;

namespace Shopy.SDK.ApiModels.Products
{
    public class ProductDetails
    {
        public Guid Uid { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public string ProductId { get; set; }

        public decimal Price { get; set; }

        public string Brand { get; set; }

        public string Size { get; set; }

        public Product[] RelatedProducts { get; set; }

        public Size[] AvailableSizes { get; set; }

        public Category[] AvailableCategories { get; set; }

        public Category[] AssignedCategories { get; set; }
    }
}
