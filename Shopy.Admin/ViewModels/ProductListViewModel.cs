using System.Collections.Generic;

namespace Shopy.Admin.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductListItemViewModel> Items { get; set; }
    }
}