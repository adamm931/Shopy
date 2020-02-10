﻿using System;
using System.Collections.Generic;

namespace Shopy.Core.Models
{
    public class CategoryReponse
    {
        public Guid Uid { get; set; }

        public string Caption { get; set; }

        public IEnumerable<CategoryProductResponse> Products { get; set; }
    }
}