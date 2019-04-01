using Mediator.Net.Contracts;

namespace Shopy.Core.Application.Products.Queries
{
    public class ListCategoriesRequest : IRequest
    {
        public bool WithProductsOnly { get; set; }
    }
}