using Shopy.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Shopy.Admin
{
    public class SelectListItemUtils
    {
        private IShopyDriver _shopyDriver;

        public SelectListItemUtils(IShopyDriver shopyDriver)
        {
            _shopyDriver = shopyDriver;
        }

        public async Task<IEnumerable<SelectListItem>> GetBrandsSL()
        {
            var brands = await _shopyDriver.ListBrandsAsync();
            return Convert(brands, b => b.Caption, b => b.EId.ToString());
        }

        public async Task<IEnumerable<SelectListItem>> GetSizesSL()
        {
            var sizes = await _shopyDriver.ListSizesAsync();
            return Convert(sizes, b => b.Caption, b => b.EId.ToString());
        }

        public async Task<MultiSelectList> GetSizesMSL()
        {
            var sizes = await _shopyDriver.ListSizesAsync();
            //var selectList = Convert(sizes, b => b.Caption, b => b.EId.ToString());
            return new MultiSelectList(sizes, "EId", "Caption");
        }

        public IEnumerable<SelectListItem> Convert<T>(
            IEnumerable<T> source,
            Func<T, string> textProvider,
            Func<T, string> valueProvider)
        {
            return source.Select(s => new SelectListItem()
            {
                Text = textProvider(s),
                Value = valueProvider(s)
            });
        }
    }
}