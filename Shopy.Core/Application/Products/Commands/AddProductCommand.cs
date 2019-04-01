using Mediator.Net.Contracts;
using Shopy.Core.Data.Entities.Enums;
using Shopy.Core.Models;
using System.Collections.Generic;

namespace Shopy.Core.Application.Products.Commands
{
    public class AddProductCommand : ICommand
    {
        public string Caption { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public BrandType Brand { get; set; }

        public SizeType Size { get; set; }

        public IEnumerable<Image> Images { get; set; }
    }
}