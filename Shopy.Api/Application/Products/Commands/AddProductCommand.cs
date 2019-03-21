using Mediator.Net.Contracts;

namespace Shopy.Api.Application.Products.Commands
{
    public class AddProductCommand : ICommand
    {
        public string Caption { get; set; }

        public string Description { get; set; }

        public string BrandType { get; set; }

        public string SizeType { get; set; }

        public decimal Price { get; set; }
    }
}