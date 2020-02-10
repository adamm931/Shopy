using MediatR;
using System;

namespace Shopy.Application.Products.AddToCategory
{
    public class AddProductToCategoryCommand : IRequest<Unit>
    {
        public Guid ProductUid { get; set; }

        public Guid CategoryUid { get; set; }

        public AddProductToCategoryCommand(Guid productUid, Guid categoryUid)
        {
            ProductUid = productUid;
            CategoryUid = categoryUid;
        }
    }
}