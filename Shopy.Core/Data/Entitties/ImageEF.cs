using System;
using System.Collections.Generic;

namespace Shopy.Core.Data.Entities
{
    public class ImageEF
    {
        public Guid Uid { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public List<ProductEF> Products { get; set; }

        public ImageEF()
        {
            Products = new List<ProductEF>();
        }
    }
}