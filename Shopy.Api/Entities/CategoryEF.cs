using System;
using System.Collections.Generic;

namespace Shopy.Api.Entities
{
    public class CategoryEF
    {
        public long CategoryID { get; set; }

        public Guid Uid { get; set; }

        public string Caption { get; set; }

        public List<ProductEF> Products { get; set; }

        public CategoryEF()
        {
            Products = new List<ProductEF>();
        }
    }
}