using System.Collections.Generic;

namespace Shopy.Admin.ViewModels
{
    public class CategoryListViewModel
    {
        public IEnumerable<CategoryListItemViewModel> Items { get; set; }
    }
}