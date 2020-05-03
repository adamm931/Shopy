using Shopy.Admin.Utils;
using Shopy.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Shopy.Admin
{
    public class SelectListUtils : ISelectListUtils
    {
        private IShopyDriver _shopyDriver;

        public SelectListUtils(IShopyDriver shopyDriver)
        {
            _shopyDriver = shopyDriver;
        }

        public async Task<IEnumerable<SelectListItem>> GetBrandsSL()
        {
            var brands = await _shopyDriver.ListBrands();
            return Convert(brands, b => b.Name, b => b.Id.ToString());
        }

        public async Task<MultiSelectList> GetSizesMSL()
        {
            var sizes = await _shopyDriver.ListSizes();
            return new MultiSelectList(sizes, "Id", "Name");
        }

        private IEnumerable<SelectListItem> Convert<T>(
            IEnumerable<T> source,
            Func<T, string> textProvider,
            Func<T, string> valueProvider)
        {
            return source.Select(s => new SelectListItem
            {
                Text = textProvider(s),
                Value = valueProvider(s)
            });
        }
    }
}