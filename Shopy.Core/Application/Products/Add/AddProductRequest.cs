using Mediator.Net.Contracts;
using Shopy.Core.Data.Entities.Enums;
using Shopy.Core.Models;
using System.Collections.Generic;

namespace Shopy.Core.Application.Products.Add
{
    public class AddProductRequest : IRequest
    {
        public string Caption { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public BrandType Brand { get; set; }

        public IEnumerable<Size> Sizes { get; set; }
    }
}