using Mediator.Net.Contracts;

namespace Shopy.Api.Application.Products.Queries
{
    public class ListCategoriesRequest : IRequest
    {
        public bool WithProductsOnly { get; set; }
    }
}