using Shopy.Core.Models;
using System.Collections.Generic;

namespace Shopy.Core.Application.Brands.Get
{
    public class ListBrandsResponse : Response<IEnumerable<BrandResponse>>
    {
        public ListBrandsResponse(IEnumerable<BrandResponse> result) : base(result)
        { }
    }
}