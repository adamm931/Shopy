using Shopy.Core.Models;
using System.Collections.Generic;

namespace Shopy.Core.Application.Products.Get
{
    public class ListProductsResponse : ListResponse<ProductReponse>
    {
        public ListProductsResponse(IEnumerable<ProductReponse> result, int totalRecords)
            : base(result, totalRecords)
        { }
    }
}