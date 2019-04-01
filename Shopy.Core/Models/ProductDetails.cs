using Shopy.Core.Data.Entities.Enums;
using System.Collections.Generic;

namespace Shopy.Core.Models
{
    public class ProductDetails : Product
    {
        public List<SizeType> AllSizes { get; set; }

        public List<Product> RelatedProducts { get; set; }
    }
}