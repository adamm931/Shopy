using System;

namespace Shopy.SDK.ApiModels.Categories
{
    public class Category
    {
        public Guid Uid { get; set; }
        public long CategoryId { get; set; }
        public string Caption { get; set; }
    }
}