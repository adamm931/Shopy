using Shopy.SDK.Models.Categories;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Shopy.Admin.ViewModels
{
    public class ChangeProductCategoiresViewModel
    {
        public IEnumerable<Category> AvailableCategories { get; set; }

        public IEnumerable<Category> AssignedCategories { get; set; }

        public IEnumerable<SelectListItem> AvailableCategories1
        {
            get
            {
                return AvailableCategories.Select(c => new SelectListItem()
                {
                    Text = c.Caption,
                    Value = $"{c.Caption}|{c.Uid.ToString()}"
                });
            }
        }
    }
}

