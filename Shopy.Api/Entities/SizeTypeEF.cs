using System;
using System.Collections.Generic;

namespace Shopy.Api.Entities
{
    public class SizeTypeEF
    {
        public string Caption { get; set; }

        public Guid SizeTypeEID { get; set; }

        public List<ProductEF> Products { get; set; }

        public SizeTypeEF()
        {
            Products = new List<ProductEF>();
        }
    }
}