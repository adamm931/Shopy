using System;
using System.Collections.Generic;

namespace Shopy.Api.Data.Models
{
    public class Product
    {
        public long ProductID { get; set; }

        public Guid Uid { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public Guid SizeEId { get; set; }

        public Guid BrandEId { get; set; }

        public SizeType Size { get; set; }

        public BrandType Brand { get; set; }

        public List<Category> Categories { get; set; }

        public Product()
        {
            Categories = new List<Category>();
        }
    }
}