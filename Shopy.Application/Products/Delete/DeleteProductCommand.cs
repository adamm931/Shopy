using MediatR;
using System;

namespace Shopy.Application.Products.Commands
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public Guid Uid { get; set; }

        public DeleteProductCommand(Guid id)
        {
            Uid = id;
        }
    }
}