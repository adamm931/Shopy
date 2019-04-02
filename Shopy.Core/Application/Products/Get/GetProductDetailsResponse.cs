using Mediator.Net.Contracts;
using Shopy.Core.Models;
using System.Collections.Generic;

namespace Shopy.Core.Application.Products.Get
{
    public class GetProductDetailsResponse : IResponse
    {
        public Product Product { get; set; }
        public IEnumerable<Product> RelatedProducts { get; set; }
        public IEnumerable<Product> OtherSizeProducts { get; set; }
    }
}