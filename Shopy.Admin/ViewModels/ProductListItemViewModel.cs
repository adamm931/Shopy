using System;

namespace Shopy.Admin.ViewModels
{
    public class ProductListItemViewModel
    {
        public int Index { get; set; }

        public Guid Uid { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}