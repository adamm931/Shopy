using MediatR;

namespace Shopy.Application.Categories.Add
{
    public class AddCategoryRequest : IRequest<AddCategoryResponse>
    {
        public string Caption { get; set; }
    }
}