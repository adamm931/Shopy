using Mediator.Net.Contracts;
using System;

namespace Shopy.Core.Application.Products.Get
{
    public class GetProductDetailsRequest : IRequest
    {
        public Guid Uid { get; set; }

        public GetProductDetailsRequest(Guid uid)
        {
            Uid = uid;
        }
    }
}