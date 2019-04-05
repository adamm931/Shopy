using System;
using System.Collections.Generic;

namespace Shopy.Sdk.Models
{
    public class AddEditProduct
    {
        public Guid Uid { get; set; }
        public string Caption { get; set; }
        public long ProductId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public IEnumerable<string> Sizes { get; set; }
    }
}
