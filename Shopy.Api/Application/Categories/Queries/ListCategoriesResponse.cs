using Shopy.Api.Models;
using System.Collections.Generic;

namespace Shopy.Api.Application.Products.Queries
{
    public class ListCategoriesResponse : Response<IEnumerable<Category>>
    {
        public ListCategoriesResponse(IEnumerable<Category> result) : base(result)
        { }
    }
}