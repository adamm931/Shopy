using System;
using System.Collections.Generic;

namespace Shopy.Api.Application.DTOS
{
    public class ProductDetailsDTO
    {
        public Guid Uid { get; set; }

        public string Caption { get; set; }

        public long ProductID { get; set; }

        public string Description { get; set; }

        public string BrandType { get; set; }

        public string SizeType { get; set; }

        public ProductCategoryDTO[] Categories { get; set; }

        public string[] AvailableSizes { get; set; }

        public List<string> RelatedProducts { get; set; }
    }
}