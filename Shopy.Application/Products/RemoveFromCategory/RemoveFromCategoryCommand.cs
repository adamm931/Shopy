using MediatR;
using System;

namespace Shopy.Application.Products.RemoveFromCategory
{
    public class RemoveProductFromCategoryCommand : IRequest<Unit>
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