using Mediator.Net.Contracts;

namespace Shopy.Core.Application.Categories.Commands
{
    public class AddCategoryRequest : IRequest
    {
        public string Caption { get; set; }
    }
}