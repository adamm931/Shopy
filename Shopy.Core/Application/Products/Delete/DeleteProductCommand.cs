using Mediator.Net.Contracts;
using System;

namespace Shopy.Core.Application.Products.Commands
{
    public class DeleteProductCommand : ICommand
    {
        public Guid Uid { get; set; }

        public DeleteProductCommand(Guid id)
        {
            Uid = id;
        }
    }
}