using Shopy.Api.Application.DTOS;
using System.Collections.Generic;

namespace Shopy.Api.Application.Products.Queries
{
    public class ListCategoriesResponse : Response<IEnumerable<CategoryDTO>>
    {
        public ListCategoriesResponse(IEnumerable<CategoryDTO> result) : base(result)
        { }
    }
}