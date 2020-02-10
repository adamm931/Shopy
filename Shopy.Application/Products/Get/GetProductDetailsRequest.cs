using MediatR;
using System;

namespace Shopy.Application.Products.Get
{
    public class GetProductDetailsRequest : IRequest<GetProductDetailsResponse>
    {
        public Guid Uid { get; set; }

        public GetProductDetailsRequest(Guid uid)
        {
            Uid = uid;
        }
    }
}