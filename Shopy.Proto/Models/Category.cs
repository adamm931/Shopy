using System;
using System.Collections.Generic;

namespace Shopy.Proto.Models
{
    public class Category
    {
        public Guid Uid { get; set; }
        public long CategoryId { get; set; }
        public string Caption { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}