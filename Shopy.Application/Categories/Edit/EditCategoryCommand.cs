using MediatR;
using System;

namespace Shopy.Application.Categories.Edit
{
    public class EditCategoryCommand : IRequest<Unit>
    {
        public Guid Uid { get; set; }

        public string Name { get; set; }
    }
}