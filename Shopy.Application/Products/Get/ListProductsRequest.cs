using MediatR;
using Shopy.Core.Models;

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