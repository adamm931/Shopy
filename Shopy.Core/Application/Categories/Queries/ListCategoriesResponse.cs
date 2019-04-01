using Shopy.Core.Models;
using System.Collections.Generic;

namespace Shopy.Core.Application.Products.Queries
{
    public class ListCategoriesResponse : Response<IEnumerable<Category>>
    {
        public ListCategoriesResponse(IEnumerable<Category> result) : base(result)
        { }
    }
}