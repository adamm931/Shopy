using Shopy.Core.Models;
using System.Collections.Generic;

namespace Shopy.Core.Application.Brands.Get
{
    public class ListBrandsResponse : Response<IEnumerable<Brand>>
    {
        public ListBrandsResponse(IEnumerable<Brand> result) : base(result)
        { }
    }
}