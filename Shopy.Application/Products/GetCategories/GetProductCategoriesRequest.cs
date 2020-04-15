using MediatR;
using System;

namespace Shopy.Application.Products.Get
{
    public class GetProductCategoriesRequest : IRequest<GetProductCategoriesResponse>
    {
        public Guid Uid { get; set; }

        public GetProductCategoriesRequest(Guid uid)
        {
            Uid = uid;
        }
    }
}