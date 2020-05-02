using MediatR;
using Shopy.Core.Domain.Entitties.Enumerations;
using System.Collections.Generic;

namespace Shopy.Application.Products.Add
{
    public class AddProductRequest : IRequest<AddProductResponse>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }

        public BrandTypeId Brand { get; set; }

        public IEnumerable<SizeTypeId> Sizes { get; set; }
    }
}