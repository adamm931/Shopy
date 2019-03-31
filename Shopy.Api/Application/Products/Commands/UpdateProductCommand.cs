using Mediator.Net.Contracts;
using Shopy.Api.Models;
using System;
using System.Collections.Generic;

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
        public IEnumerable<Image> Images { get; set; }
    }
}