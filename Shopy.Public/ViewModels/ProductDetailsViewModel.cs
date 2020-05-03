using System;
using System.Collections.Generic;

namespace Shopy.Public.ViewModels
{
    public class ProductDetailsViewModel
    {
        public Guid Uid { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Image1Url { get; set; }

        public string Image2Url { get; set; }

        public string Image3Url { get; set; }

        public IEnumerable<string> Sizes { get; set; }

        public IEnumerable<RelatedProductViewModel> RelatedProducts { get; set; }
    }
}