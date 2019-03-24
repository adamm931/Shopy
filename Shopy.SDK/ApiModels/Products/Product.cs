using Shopy.SDK.ApiModels.Categories;
using System;

namespace Shopy.SDK.ApiModels.Products
{
    public class Product
    {
        public Guid Uid { get; set; }
        public string Caption { get; set; }
        public long ProductID { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Size { get; set; }
        public Category[] Categories { get; set; }
    }
}