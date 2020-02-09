using System;
using System.Collections.Generic;

namespace Shopy.Core.Models
{
    public class CategoryReponse
    {
        public Guid Uid { get; set; }

        public int Id { get; set; }

        public string Caption { get; set; }

        public List<ProductReponse> Products { get; set; }
    }
}