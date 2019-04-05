using Mediator.Net.Contracts;
using System;
using System.Collections.Generic;

namespace Shopy.Core.Application.Products.Edit
{
    public class EditProductCommand : ICommand
    {
        public Guid Uid { get; set; }
        public decimal? Price { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public IEnumerable<string> Sizes { get; set; }
    }
}