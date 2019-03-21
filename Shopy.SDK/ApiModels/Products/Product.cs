using Shopy.SDK.Models.Categories;
using System;

namespace Shopy.SDK.Models.Products
{
    public class Product
    {
        public Guid Uid { get; set; }
        public string Caption { get; set; }
        public long ProductID { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string BrandType { get; set; }
        public string SizeType { get; set; }
        public Category[] Categories { get; set; }
    }
}