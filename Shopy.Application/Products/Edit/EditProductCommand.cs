using MediatR;
using Shopy.Core.Domain.Entitties.Enumerations;
using System;
using System.Collections.Generic;

namespace Shopy.Application.Products.Edit
{
    public class EditProductCommand : IRequest<Unit>
    {
        public Guid Uid { get; set; }
        public decimal? Price { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public BrandTypeId Brand { get; set; }
        public IEnumerable<SizeTypeId> Sizes { get; set; }
    }
}