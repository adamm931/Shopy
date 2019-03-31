using System;
using System.Collections.Generic;

namespace Shopy.Api.Models
{
    public class Category
    {
        public Guid Uid { get; set; }

        public int CategoryId { get; set; }

        public string Caption { get; set; }

        public List<Product> Products { get; set; }
    }
}