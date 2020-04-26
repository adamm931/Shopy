using System;
using System.Collections.Generic;

namespace Shopy.Application.Models
{
    public class CategoryReponse
    {
        public Guid Uid { get; set; }

        public string Name { get; set; }

        public IEnumerable<CategoryProductResponse> Products { get; set; }
    }
}