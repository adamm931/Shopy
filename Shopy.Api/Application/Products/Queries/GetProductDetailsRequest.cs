using Mediator.Net.Contracts;

namespace Shopy.Api.Application.Products.Queries
{
    public class GetProductDetailsRequest : IRequest
    {
        public string Sku { get; set; }
    }
}