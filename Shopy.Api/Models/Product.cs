using System;
using System.Collections.Generic;

namespace Shopy.Api.Models
{
    public class Product
    {
        public Guid Uid { get; set; }

        public string Caption { get; set; }

        public string Sku { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public Brand Brand { get; set; }

        public Size Size { get; set; }

        public List<Image> Images { get; set; }
    }
}