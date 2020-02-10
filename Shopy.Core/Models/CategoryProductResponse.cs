using System;
using System.Collections.Generic;

namespace Shopy.Core.Models
{
    public class CategoryProductResponse
    {
        public Guid Uid { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public BrandResponse Brand { get; set; }

        public IEnumerable<SizeResponse> Sizes { get; set; }
    }
}
