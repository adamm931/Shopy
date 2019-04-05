using System;
using System.Collections.Generic;

namespace Shopy.Sdk.Models
{
    public class Product
    {
        public Guid Uid { get; set; }
        public string Caption { get; set; }
        public long ProductId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Brand Brand { get; set; }
        public IEnumerable<Size> Sizes { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}