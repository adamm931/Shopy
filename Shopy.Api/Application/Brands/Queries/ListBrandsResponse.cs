using Shopy.Api.Models;
using System.Collections.Generic;

namespace Shopy.Api.Application.Products.Queries
{
    public class ListBrandsResponse : Response<IEnumerable<Brand>>
    {
        public ListBrandsResponse(IEnumerable<Brand> result) : base(result)
        { }
    }
}