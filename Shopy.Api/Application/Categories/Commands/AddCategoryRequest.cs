using Mediator.Net.Contracts;

namespace Shopy.Api.Application.Categories.Commands
{
    public class AddCategoryRequest : IRequest
    {
        public string Caption { get; set; }
    }
}