using Shopy.Core.Models;
using System.Collections.Generic;

namespace Shopy.Core.Application.Products.Queries
{
    public class ListBrandsResponse : Response<IEnumerable<Brand>>
    {
        public ListBrandsResponse(IEnumerable<Brand> result) : base(result)
        { }
    }
}