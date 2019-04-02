using Mediator.Net.Contracts;
using Shopy.Core.Data.Entities.Enums;
using Shopy.Core.Models;
using System;
using System.Collections.Generic;

namespace Shopy.Core.Application.Products.Edit
{
    public class EditProductCommand : ICommand
    {
        public Guid Uid { get; set; }
        public decimal Price { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public BrandType Brand { get; set; }
        public IEnumerable<Size> Sizes { get; set; }
    }
}