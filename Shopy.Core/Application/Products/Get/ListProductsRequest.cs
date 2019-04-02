using Mediator.Net.Contracts;
using Shopy.Core.Models;

namespace Shopy.Core.Application.Products.Get
{
    public class ListProductsRequest : IRequest
    {
        public ProductFilter Filter { get; set; }

        public ListProductsRequest(ProductFilter filter)
        {
            Filter = filter;
        }
    }
}