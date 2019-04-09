using Mediator.Net.Contracts;
using System;

namespace Shopy.Core.Application.Categories.Delete
{
    public class DeleteCategoryCommand : ICommand
    {
        public Guid Uid { get; set; }

        public DeleteCategoryCommand(Guid uid)
        {
            Uid = uid;
        }
    }
}
