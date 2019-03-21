using Mediator.Net.Contracts;
using System;

namespace Shopy.Api.Application.Products.Commands
{
    public class RemoveProductFromCategoryCommand : ICommand
    {
        public Guid ProductUid { get; set; }

        public Guid CategoryUid { get; set; }
    }
}