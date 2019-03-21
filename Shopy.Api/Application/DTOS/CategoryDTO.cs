using System;
using System.Collections.Generic;

namespace Shopy.Api.Application.DTOS
{
    public class CategoryDTO
    {
        public Guid Uid { get; set; }
        public string Caption { get; set; }

        public List<CategoryProductDTO> Products { get; set; }
    }
}