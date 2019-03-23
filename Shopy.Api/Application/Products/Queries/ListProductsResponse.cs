using Shopy.Api.Models;
using System.Collections.Generic;

namespace Shopy.Api.Application.Products.Queries
{
    public class ListProductsResponse : Response<IEnumerable<Product>>
    {
        public ListProductsResponse(IEnumerable<Product> result) : base(result)
        { }
    }
}