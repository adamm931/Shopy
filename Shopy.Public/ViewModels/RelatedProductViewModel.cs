using System;
using System.Collections.Generic;

namespace Shopy.Public.ViewModels
{
    public class RelatedProductViewModel
    {
        public Guid Uid { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string MainImageUrl { get; set; }

        public IEnumerable<string> Sizes { get; set; }
    }
}