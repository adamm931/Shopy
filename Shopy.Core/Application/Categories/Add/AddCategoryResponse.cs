using Shopy.Core.Models;

namespace Shopy.Core.Application.Categories.Add
{
    public class AddCategoryResponse : Response<CategoryReponse>
    {
        public AddCategoryResponse(CategoryReponse result) : base(result)
        { }
    }
}