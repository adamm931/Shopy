using Shopy.Core.Domain.Entitties.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopy.Sdk.Models
{
    public class ProductFilter
    {
        public IEnumerable<SizeTypeId> Sizes { get; set; }

        public IEnumerable<BrandTypeId> Brands { get; set; }

        public int? PageIndex { get; set; }

        public int? PageSize { get; set; }

        public decimal? MaxPrice { get; set; }

        public decimal? MinPrice { get; set; }

        public Guid? CategoryUid { get; set; }

        public ProductFilter()
        {
            Sizes = Enumerable.Empty<SizeTypeId>();
            Brands = Enumerable.Empty<BrandTypeId>();
        }

        public string GetQueryString()
        {
            var @params = new Dictionary<string, object>();

            if (Brands.Any())
            {
                @params.Add("brands", string.Join(",", Brands));
            }

            if (Sizes.Any())
            {
                @params.Add("sizes", string.Join(",", Sizes));
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

            if (CategoryUid.HasValue)
            {
                @params.Add("categoryUid", CategoryUid.Value);
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
