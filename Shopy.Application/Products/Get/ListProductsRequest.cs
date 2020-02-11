using MediatR;
using Shopy.Application.Models;

namespace Shopy.Application.Products.Get
{
    public class ListProductsRequest : IRequest<ListProductsResponse>
    {
        public ProductFilter Filter { get; set; }

        public ListProductsRequest(ProductFilter filter)
        {
            Filter = filter;
        }
    }
}