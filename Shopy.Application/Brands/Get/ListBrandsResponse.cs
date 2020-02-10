using Shopy.Core.Domain.Entitties;
using Shopy.Core.Models;
using System.Collections.Generic;

namespace Shopy.Application.Brands.Get
{
    public class ListBrandsResponse : Response<IEnumerable<BrandResponse>, IEnumerable<BrandType>>
    {
        public ListBrandsResponse(IEnumerable<BrandType> domainModel) : base(domainModel)
        { }
    }
}