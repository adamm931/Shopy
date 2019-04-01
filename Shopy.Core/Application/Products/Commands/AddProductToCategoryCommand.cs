using Mediator.Net.Contracts;
using System;

namespace Shopy.Core.Application.Products.Commands
{
    public class AddProductFromCategoryCommand : ICommand
    {
        public Guid ProductUid { get; set; }

        public Guid CategoryUid { get; set; }

        public AddProductFromCategoryCommand(Guid productUid, Guid categoryUid)
        {
            ProductUid = productUid;
            CategoryUid = categoryUid;
        }
    }
}