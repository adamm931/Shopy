using Mediator.Net.Contracts;

namespace Shopy.Api.Application.Products.Queries
{
    public class ListBrandsRequest : IRequest
    {
        public bool WithProductsOnly { get; set; }
    }
}