using Mediator.Net.Contracts;
using System;
using System.Collections.Generic;

namespace Shopy.Core.Application.Categories.Edit
{
    public class EditCategoryCommand : ICommand
    {
        public Guid Uid { get; set; }
        public string Caption { get; set; }
    }
}