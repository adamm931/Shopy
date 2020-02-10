using MediatR;
using System;

namespace Shopy.Application.Products.Get
{
    public class GetProductRequest : IRequest<GetProductResponse>
    {
        public Guid Uid { get; set; }

        public GetProductRequest(Guid uid)
        {
            Uid = uid;
        }
    }
}