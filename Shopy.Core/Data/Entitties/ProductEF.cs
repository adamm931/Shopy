using Shopy.Core.Data.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Shopy.Core.Data.Entities
{
    public class ProductEF
    {
        public Guid Uid { get; set; }

        public long ProductId { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public SizeType SizeEId { get; set; }

        public BrandType BrandEId { get; set; }

        public SizeTypeEF Size { get; set; }

        public BrandTypeEF Brand { get; set; }

        public List<CategoryEF> Categories { get; set; }

        public ProductEF()
        {
            Categories = new List<CategoryEF>();
        }
    }
}