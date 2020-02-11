using Shopy.Core.Domain.Entitties;
using Shopy.Application.Models;
using System.Collections.Generic;

namespace Shopy.Application.Products.Get
{
    public class ListProductsResponse : ListResponse<ProductResponse, Product>
    {
        public ListProductsResponse(IEnumerable<Product> result, int totalRecords)
            : base(result, totalRecords)
        { }
    }
}