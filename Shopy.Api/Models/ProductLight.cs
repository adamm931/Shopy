using System;

namespace Shopy.Api.Models
{
    public class ProductLight
    {
        public Guid Uid { get; set; }

        public string Caption { get; set; }

        public long ProductId { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Brand { get; set; }

        public string Size { get; set; }

        public string DisplayImage { get; set; }
    }
}