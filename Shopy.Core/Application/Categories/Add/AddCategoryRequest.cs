using Mediator.Net.Contracts;

namespace Shopy.Core.Application.Categories.Add
{
    public class AddCategoryRequest : IRequest
    {
        public string Caption { get; set; }
    }
}