﻿using Mediator.Net.Contracts;
using System.Collections.Generic;

namespace Shopy.Core.Application.Products.Add
{
    public class AddProductRequest : IRequest
    {
        public string Caption { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }

        public string Brand { get; set; }

        public IEnumerable<string> Sizes { get; set; }
    }
}