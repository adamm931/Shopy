using System;

namespace SampleApi.Application.Products.Queries
{
    public class ProductDTO
    {
        public Guid Uid { get; set; }

        public Guid Caption { get; set; }

        public string CategoryName { get; set; }
    }
}