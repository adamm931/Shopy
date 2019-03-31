using Shopy.Api.Data.Entities.Enums;
using System.Collections.Generic;

namespace Shopy.Api.Data.Entities
{
    public class BrandTypeEF
    {
        public string Caption { get; set; }

        public BrandType BrandTypeEId { get; set; }

        public List<ProductEF> Products { get; set; }

        public BrandTypeEF()
        {
            Products = new List<ProductEF>();
        }
    }
}