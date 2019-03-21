using System;
using System.Collections.Generic;

namespace Shopy.Api.Data.Models
{
    public class BrandType
    {
        public string Caption { get; set; }

        public Guid BrandTypeEId { get; set; }

        public List<Product> Products { get; set; }

        public BrandType()
        {
            Products = new List<Product>();
        }

    }
}