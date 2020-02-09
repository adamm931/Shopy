using Shopy.Core.Domain.Entitties.Base;
using Shopy.Core.Domain.Entitties.Enumerations;
using System.Collections.Generic;

namespace Shopy.Core.Domain.Entitties
{
    public class SizeType : EnumEntity<SizeTypeId>
    {
        public List<Product> Products { get; set; }

        private SizeType(SizeTypeId value) : base(value)
        {
            Products = new List<Product>();
        }

        private SizeType()
        {
        }

        public static SizeType From(SizeTypeId sizeTypeId)
            => new SizeType(sizeTypeId);
    }
}