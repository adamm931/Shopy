using Shopy.Core.Domain.Entitties.Base;
using Shopy.Core.Domain.Entitties.Enumerations;
using System.Collections.Generic;

namespace Shopy.Core.Domain.Entitties
{
    public class BrandType : EnumEntity<BrandTypeId>
    {
        public List<Product> Products { get; set; }

        private BrandType(BrandTypeId value) : base(value)
        {
            Products = new List<Product>();
        }

        private BrandType()
        {
        }

        public static BrandType From(BrandTypeId brandTypeId)
            => new BrandType(brandTypeId);

    }
}