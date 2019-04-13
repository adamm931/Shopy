using Shopy.Core.Models;

namespace Shopy.Core.Application.Categories.Add
{
    public class GetCategoryResponse : Response<Category>
    {
        public GetCategoryResponse(Category result) : base(result)
        { }
    }
}