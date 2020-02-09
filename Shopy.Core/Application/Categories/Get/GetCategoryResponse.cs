using Shopy.Core.Models;

namespace Shopy.Core.Application.Categories.Add
{
    public class GetCategoryResponse : Response<CategoryReponse>
    {
        public GetCategoryResponse(CategoryReponse result) : base(result)
        { }
    }
}