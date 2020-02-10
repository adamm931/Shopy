using Shopy.Core.Domain.Entitties;
using Shopy.Core.Models;
using System.Collections.Generic;

namespace Shopy.Application.Sizes.Get
{
    public class ListSizesResponse : Response<IEnumerable<SizeResponse>, IEnumerable<SizeType>>
    {
        public ListSizesResponse(IEnumerable<SizeType> domainModel) : base(domainModel)
        { }
    }
}