using System;

namespace Shopy.Admin.ViewModels
{
    public class CategoryListItemViewModel
    {
        public Guid Uid { get; set; }
        public long CategoryId { get; set; }
        public string Caption { get; set; }
    }
}