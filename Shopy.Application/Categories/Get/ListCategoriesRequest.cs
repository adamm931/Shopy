using MediatR;

namespace Shopy.Application.Categories.Get
{
    public class ListCategoriesRequest : IRequest<ListCategoriesResponse>
    {
        public bool WithProductsOnly { get; set; }

        public ListCategoriesRequest(bool withProductsOnly)
        {
            WithProductsOnly = withProductsOnly;
        }
    }
}