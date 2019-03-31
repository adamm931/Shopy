using Mediator.Net.Contracts;
using Shopy.Api.Models;
using System.Collections.Generic;

namespace Shopy.Api.Application.Products.Queries
{
    public class GetProductDetailsResponse : IResponse
    {
        public Product Product { get; set; }
        public IEnumerable<Product> RelatedProducts { get; set; }
        public IEnumerable<Product> OtherSizeProducts { get; set; }
    }
}