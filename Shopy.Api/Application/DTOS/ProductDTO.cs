using System;
using System.Collections.Generic;

namespace Shopy.Api.Application.DTOS
{
    public class ProductDTO
    {
        public Guid Uid { get; set; }

        public string Caption { get; set; }

        public long ProductID { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string BrandType { get; set; }

        public string SizeType { get; set; }

        public List<ProductCategoryDTO> Categories { get; set; }
    }
}