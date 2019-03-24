using Mediator.Net.Contracts;
using Shopy.Api.Models;

namespace Shopy.Api.Application.Products.Queries
{
    public class ListProductsRequest : IRequest
    {
        public ProductFilter Filter { get; set; }
    }
}