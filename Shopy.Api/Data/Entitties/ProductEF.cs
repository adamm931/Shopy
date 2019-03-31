using Shopy.Api.Common;
using Shopy.Api.Data.Entities.Enums;
using Shopy.Data;
using System;
using System.Collections.Generic;

namespace Shopy.Api.Data.Entities
{
    public class ProductEF
    {
        public Guid Uid { get; set; }

        public string Sku { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public SizeType SizeEId { get; set; }

        public BrandType BrandEId { get; set; }

        public SizeTypeEF Size { get; set; }

        public BrandTypeEF Brand { get; set; }

        public List<CategoryEF> Categories { get; set; }

        public List<ImageEF> Images { get; set; }

        public ProductEF()
        {
            Categories = new List<CategoryEF>();
            Images = new List<ImageEF>();
        }

        public void SetSku(ShopyContext context)
        {
            Sku = $"{Caption.Substring(0, 3)}-"
                + $"{Description.Substring(0, 3)}-"
                + $"{Brand.Caption.Substring(0, 3)}-"
                + $"{Size.Caption.Substring(0, 3)}-"
                + $"{context.GetValueFromSequence(Constants.ProductsSerial)}";
        }
    }
}