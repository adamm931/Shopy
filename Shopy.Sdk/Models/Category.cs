using System;
using System.Collections.Generic;

namespace Shopy.Sdk.Models
{
    public class Category
    {
        public Guid Uid { get; set; }

        public string Name { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}