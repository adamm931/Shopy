using Shopy.Core.Models;
using System.Collections.Generic;

namespace Shopy.Core.Application.Sizes.Get
{
    public class ListSizesResponse : Response<IEnumerable<SizeResponse>>
    {
        public ListSizesResponse(IEnumerable<SizeResponse> result) : base(result)
        { }
    }
}