using Shopy.Core.Models;
using System.Collections.Generic;

namespace Shopy.Core.Application.Products.Get
{
    public class ListProductsResponse : ListResponse<Product>
    {
        public ListProductsResponse(IEnumerable<Product> result, int totalRecords)
            : base(result, totalRecords)
        { }
    }
}