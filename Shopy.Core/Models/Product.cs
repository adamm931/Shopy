using Shopy.Core.Data.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Shopy.Core.Models
{
    public class Product
    {
        public Guid Uid { get; set; }

        public long ProductId { get; set; }

        public string Caption { get; set; }

        public string Sku { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public BrandType Brand { get; set; }

        public SizeType Size { get; set; }

        public List<Image> Images { get; set; }
    }
}