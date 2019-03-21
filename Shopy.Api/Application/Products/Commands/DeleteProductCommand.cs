using Mediator.Net.Contracts;
using System;

namespace Shopy.Api.Application.Products.Commands
{
    public class DeleteProductCommand : ICommand
    {
        public Guid Uid { get; set; }
    }
}