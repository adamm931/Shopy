using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Shopy.Admin
{
    public class SelectListItemConverter
    {
        public static IEnumerable<SelectListItem> Convert<T>(
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