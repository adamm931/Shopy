using Shopy.Api.Data.Entities.Enums;
using System.Collections.Generic;

namespace Shopy.Api.Data.Entities
{
    public class SizeTypeEF
    {
        public string Caption { get; set; }

        public SizeType SizeTypeEID { get; set; }

        public List<ProductEF> Products { get; set; }

        public SizeTypeEF()
        {
            Products = new List<ProductEF>();
        }
    }
}