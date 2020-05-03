using System.Collections.Generic;

namespace Shopy.Public.ViewModels
{
    public class ProductFiltersViewModel
    {
        public IEnumerable<FilterViewModel> SizeFilters { get; set; }

        public IEnumerable<FilterViewModel> CategoryFilters { get; set; }

        public IEnumerable<FilterViewModel> BrandFilters { get; set; }

    }
}