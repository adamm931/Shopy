using System;
using System.Collections.Generic;

namespace Shopy.Api.Data.Entities
{
    public class CategoryEF
    {
        public Guid Uid { get; set; }

        public int CategoryId { get; set; }

        public string Caption { get; set; }

        public List<ProductEF> Products { get; set; }

        public CategoryEF()
        {
            Products = new List<ProductEF>();
        }
    }
}