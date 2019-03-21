using System;
using System.Collections.Generic;

namespace Shopy.Api.Data.Models
{
    public class Category
    {
        public long CategoryID { get; set; }

        public Guid Uid { get; set; }

        public string Caption { get; set; }

        public List<Product> Products { get; set; }

        public Category()
        {
            Products = new List<Product>();
        }
    }
}