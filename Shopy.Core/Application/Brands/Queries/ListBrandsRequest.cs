using Mediator.Net.Contracts;

namespace Shopy.Core.Application.Products.Queries
{
    public class ListBrandsRequest : IRequest
    {
        public bool WithProductsOnly { get; set; }
    }
}