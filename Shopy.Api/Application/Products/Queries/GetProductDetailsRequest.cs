using Mediator.Net.Contracts;
using System;

namespace Shopy.Api.Application.Products.Queries
{
    public class GetProductDetailsRequest : IRequest
    {
        public Guid Uid { get; set; }
    }
}