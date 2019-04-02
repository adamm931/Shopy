using Shopy.Core.Models;

namespace Shopy.Core.Application.Categories.Add
{
    public class AddCategoryResponse : Response<Category>
    {
        public AddCategoryResponse(Category result) : base(result)
        { }
    }
}