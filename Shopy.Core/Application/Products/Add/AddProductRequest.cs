using Mediator.Net.Contracts;
using Shopy.Core.Domain.Entitties.Enumerations;
using System.Collections.Generic;

namespace Shopy.Core.Application.Products.Add
{
    public class AddProductRequest : IRequest
    {
        public string Caption { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }

        public BrandTypeId Brand { get; set; }

        public IEnumerable<SizeTypeId> Sizes { get; set; }
    }
}