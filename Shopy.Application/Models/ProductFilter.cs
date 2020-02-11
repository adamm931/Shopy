using System;

namespace Shopy.Application.Models
{
    public class ProductFilter
    {
        public string Sizes { get; set; }

        public string Brands { get; set; }

        public Guid? CategoryUid { get; set; }

        public int? PageIndex { get; set; }

        public int? PageSize { get; set; }

        public decimal? MaxPrice { get; set; }

        public decimal? MinPrice { get; set; }
    }
}