using Shopy.Core.Domain.Entitties;
using Shopy.Application.Models;
using System.Collections.Generic;

namespace Shopy.Application.Categories.Get
{
    public class ListCategoriesResponse : Response<IEnumerable<CategoryReponse>, IEnumerable<Category>>
    {
        public ListCategoriesResponse(IEnumerable<Category> domainModel) : base(domainModel)
        { }
    }
}