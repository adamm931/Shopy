using Mediator.Net.Contracts;
using Shopy.Api.Models;
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
        public string Brand { get; set; }
        public string Size { get; set; }
        public IEnumerable<CategoryLight> AvailableCategories { get; set; }
        public IEnumerable<CategoryLight> AssignedCategories { get; set; }
    }
}