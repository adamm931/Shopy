
using Shopy.SDK.ApiModels.Categories;

namespace Shopy.SDK.ApiModels.Products
{
    public class ProductDetails
    {
        public string Caption { get; set; }

        public string Description { get; set; }

        public string ProductID { get; set; }

        public decimal Price { get; set; }

        public string BrandType { get; set; }

        public string SizeType { get; set; }

        public Category[] AvailableCategories { get; set; }

        public Category[] AssignedCategories { get; set; }
    }
}
