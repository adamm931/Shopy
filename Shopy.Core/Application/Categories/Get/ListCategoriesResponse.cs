using Shopy.Core.Models;
using System.Collections.Generic;

namespace Shopy.Core.Application.Categories.Get
{
    public class ListCategoriesResponse : Response<IEnumerable<CategoryReponse>>
    {
        public ListCategoriesResponse(IEnumerable<CategoryReponse> result) : base(result)
        { }
    }
}