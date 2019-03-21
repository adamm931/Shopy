using Shopy.Api.Application.DTOS;
using System.Collections.Generic;

namespace Shopy.Api.Application.Products.Queries
{
    public class ListProductsResponse : Response<IEnumerable<ProductDTO>>
    {
        public ListProductsResponse(IEnumerable<ProductDTO> result) : base(result)
        { }
    }
}