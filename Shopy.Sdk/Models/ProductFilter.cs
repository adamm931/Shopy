using System.Collections.Generic;
using System.Linq;

namespace Shopy.Sdk.Models
{
    public class ProductFilter
    {
        public string Sizes { get; set; }

        public string Brands { get; set; }

        public int? PageIndex { get; set; }

        public int? PageSize { get; set; }

        public decimal? MaxPrice { get; set; }

        public decimal? MinPrice { get; set; }

        public string GetQueryString()
        {
            var @params = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(Brands))
            {
                @params.Add("brands", Brands);
            }

            if (!string.IsNullOrEmpty(Sizes))
            {
                @params.Add("sizes", Sizes);
            }

            if (MinPrice.HasValue)
            {
                @params.Add("minPrice", MinPrice.Value);
            }

            if (MaxPrice.HasValue)
            {
                @params.Add("maxPrice", MaxPrice.Value);
            }

            if (PageIndex.HasValue && PageSize.HasValue)
            {
                @params.Add("pageIndex", PageIndex.Value);
                @params.Add("pageSize", PageSize.Value);
            }

            if (!@params.Any())
            {
                return string.Empty;
            }

            var query = string.Join(
                    "&", @params.Select(kvp => $"{kvp.Key}={kvp.Value}"));

            return $"?{query}";

        }
    }
}
