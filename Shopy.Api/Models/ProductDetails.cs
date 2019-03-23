using System;
using System.Collections.Generic;

namespace Shopy.Api.Models
{
    public class ProductDetails
    {
        public Guid Uid { get; set; }

        public string Caption { get; set; }

        public long ProductID { get; set; }

        public string Description { get; set; }

        public string Brand { get; set; }

        public string Size { get; set; }

        public List<Size> AvailableSizes { get; set; }

        public List<ProductLight> RelatedProducts { get; set; }
    }
}