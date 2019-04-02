using Mediator.Net.Contracts;
using Shopy.Core.Data.Entities.Enums;
using System;

namespace Shopy.Core.Application.Products.Edit
{
    public class EditProductCommand : ICommand
    {
        public Guid Uid { get; set; }
        public decimal Price { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public BrandType Brand { get; set; }
        public SizeType Size { get; set; }
    }
}