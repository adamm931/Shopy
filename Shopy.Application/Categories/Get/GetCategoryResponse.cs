using Shopy.Core.Domain.Entitties;
using Shopy.Core.Models;

namespace Shopy.Application.Categories.Add
{
    public class GetCategoryResponse : Response<CategoryReponse, Category>
    {
        public GetCategoryResponse(Category domainModel) : base(domainModel)
        { }
    }
}