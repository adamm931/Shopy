using Mediator.Net.Contracts;
using System;

namespace Shopy.Core.Application.Products.Queries
{
    public class GetProductRequest : IRequest
    {
        public Guid Uid { get; set; }

        public GetProductRequest(Guid uid)
        {
            Uid = uid;
        }
    }
}