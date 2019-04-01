using Shopy.Core.Models;
using System.Collections.Generic;

namespace Shopy.Core.Application.Products.Queries
{
    public class ListProductsResponse : Response<IEnumerable<Product>>
    {
        public ListProductsResponse(IEnumerable<Product> result) : base(result)
        { }
    }
}