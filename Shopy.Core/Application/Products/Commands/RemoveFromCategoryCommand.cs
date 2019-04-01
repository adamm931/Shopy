using Mediator.Net.Contracts;
using System;

namespace Shopy.Core.Application.Products.Commands
{
    public class RemoveProductFromCategoryCommand : ICommand
    {
        public Guid ProductUid { get; set; }

        public Guid CategoryUid { get; set; }

        public RemoveProductFromCategoryCommand(Guid productUid, Guid categoryUid)
        {
            ProductUid = productUid;
            CategoryUid = categoryUid;
        }
    }
}