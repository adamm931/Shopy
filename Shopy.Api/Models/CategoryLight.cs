using System;

namespace Shopy.Api.Models
{
    public class CategoryLight
    {
        public Guid Uid { get; set; }

        public long CategoryId { get; set; }

        public string Caption { get; set; }
    }
}