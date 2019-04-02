using Mediator.Net.Contracts;

namespace Shopy.Core.Application.Brands.Get
{
    public class ListBrandsRequest : IRequest
    {
        public bool WithProductsOnly { get; set; }
    }
}