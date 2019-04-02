using System;

namespace Shopy.Admin.ViewModels
{
    public class ProductListItemViewModel
    {
        public Guid Uid { get; set; }

        public long ProductId { get; set; }

        public string Caption { get; set; }

        public decimal Price { get; set; }
    }
}