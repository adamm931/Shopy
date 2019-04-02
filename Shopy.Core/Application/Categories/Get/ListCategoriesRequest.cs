using Mediator.Net.Contracts;

namespace Shopy.Core.Application.Categories.Get
{
    public class ListCategoriesRequest : IRequest
    {
        public bool WithProductsOnly { get; set; }

        public ListCategoriesRequest(bool withProductsOnly)
        {
            WithProductsOnly = withProductsOnly;
        }
    }
}