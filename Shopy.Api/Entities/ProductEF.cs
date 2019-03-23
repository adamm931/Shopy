using System;
using System.Collections.Generic;

namespace Shopy.Api.Entities
{
    public class ProductEF
    {
        public long ProductID { get; set; }

        public Guid Uid { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public Guid SizeEId { get; set; }

        public Guid BrandEId { get; set; }

        public SizeTypeEF Size { get; set; }

        public BrandTypeEF Brand { get; set; }

        public List<CategoryEF> Categories { get; set; }

        public ProductEF()
        {
            Categories = new List<CategoryEF>();
        }
    }
}