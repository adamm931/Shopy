using Shopy.Api.Models;
using System.Collections.Generic;

namespace Shopy.Api.Application.Products.Queries
{
    public class ListSizesResponse : Response<IEnumerable<Size>>
    {
        public ListSizesResponse(IEnumerable<Size> result) : base(result)
        { }
    }
}