using Shopy.Core.Models;
using System.Collections.Generic;

namespace Shopy.Core.Application.Categories.Get
{
    public class ListCategoriesResponse : Response<IEnumerable<Category>>
    {
        public ListCategoriesResponse(IEnumerable<Category> result) : base(result)
        { }
    }
}