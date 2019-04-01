using System;
using System.Collections.Generic;

namespace Shopy.Core.Models
{
    public class Category
    {
        public Guid Uid { get; set; }

        public int CategoryId { get; set; }

        public string Caption { get; set; }

        public List<Product> Products { get; set; }
    }
}