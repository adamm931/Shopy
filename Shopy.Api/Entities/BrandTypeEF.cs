using System;
using System.Collections.Generic;

namespace Shopy.Api.Entities
{
    public class BrandTypeEF
    {
        public string Caption { get; set; }

        public Guid BrandTypeEId { get; set; }

        public List<ProductEF> Products { get; set; }

        public BrandTypeEF()
        {
            Products = new List<ProductEF>();
        }

    }
}