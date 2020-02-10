using Shopy.Core.Domain.Entitties;
using Shopy.Core.Models;

namespace Shopy.Application.Categories.Add
{
    public class AddCategoryResponse : Response<CategoryReponse, Category>
    {
        public AddCategoryResponse(Category domainModel) : base(domainModel)
        { }
    }
}