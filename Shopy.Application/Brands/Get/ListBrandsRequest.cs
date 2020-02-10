using MediatR;

namespace Shopy.Application.Brands.Get
{
    public class ListBrandsRequest : IRequest<ListBrandsResponse>
    {
        public bool WithProductsOnly { get; set; }
    }
}