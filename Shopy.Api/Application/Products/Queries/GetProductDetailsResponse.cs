using Mediator.Net.Contracts;
using Shopy.Api.Application.DTOS;
using System;
using System.Collections.Generic;

namespace Shopy.Api.Application.Products.Queries
{
    public class GetProductDetailsResponse : IResponse
    {
        public Guid Uid { get; set; }
        public long ProductID { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string BrandType { get; set; }
        public string SizeType { get; set; }
        public IEnumerable<ProductCategoryDTO> AvailableCategories { get; set; }
        public IEnumerable<ProductCategoryDTO> AssignedCategories { get; set; }
    }
}