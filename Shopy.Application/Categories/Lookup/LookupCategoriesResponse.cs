using Shopy.Application.Models;
using Shopy.Core.Domain.Entitties;
using System.Collections.Generic;

namespace Shopy.Application.Categories.Add
{
    public class LookupCategoriesResponse : ListResponse<LookupResponse, Category>
    {
        public LookupCategoriesResponse(IEnumerable<Category> domainModel) : base(domainModel)
        { }
    }
}