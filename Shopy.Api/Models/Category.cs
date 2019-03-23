using System;
using System.Collections.Generic;

namespace Shopy.Api.Models
{
    public class Category
    {
        public Guid Uid { get; set; }

        public long CategoryId { get; set; }

        public string Caption { get; set; }

        public List<ProductLight> Products { get; set; }
    }
}