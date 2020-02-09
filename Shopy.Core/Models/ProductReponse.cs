using Shopy.Core.Domain.Entitties.Enumerations;
using System;
using System.Collections.Generic;

namespace Shopy.Core.Models
{
    public class ProductReponse
    {
        public long Id { get; set; }

        public Guid Uid { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public BrandTypeId Brand { get; set; }

        public IEnumerable<SizeTypeId> Sizes { get; set; }

        public IEnumerable<CategoryReponse> Categories { get; set; }

    }
}