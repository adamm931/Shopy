using System;

namespace Shopy.Api.Application.DTOS
{
    public class CategoryProductDTO
    {
        public Guid Uid { get; set; }

        public string Size { get; set; }

        public string Brand { get; set; }
    }
}