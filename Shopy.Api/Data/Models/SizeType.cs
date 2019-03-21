using System;
using System.Collections.Generic;

namespace Shopy.Api.Data.Models
{
    public class SizeType
    {
        public string Caption { get; set; }

        public Guid SizeTypeEID { get; set; }

        public List<Product> Products { get; set; }

        public SizeType()
        {
            Products = new List<Product>();
        }
    }
}