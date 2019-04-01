using Shopy.Core.Models;
using System.Collections.Generic;

namespace Shopy.Core.Application.Products.Queries
{
    public class ListSizesResponse : Response<IEnumerable<Size>>
    {
        public ListSizesResponse(IEnumerable<Size> result) : base(result)
        { }
    }
}