using MediatR;
using System;

namespace Shopy.Application.Categories.Delete
{
    public class DeleteCategoryCommand : IRequest<Unit>
    {
        public Guid Uid { get; set; }

        public DeleteCategoryCommand(Guid uid)
        {
            Uid = uid;
        }
    }
}
