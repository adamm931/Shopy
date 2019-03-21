using Mediator.Net.Contracts;
using System;

namespace Shopy.Api.Application.Products.Commands
{
    public class UpdateProductCommand : ICommand
    {
        public Guid Uid { get; set; }
        public decimal Price { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string BrandType { get; set; }
        public string SizeType { get; set; }

    }
}