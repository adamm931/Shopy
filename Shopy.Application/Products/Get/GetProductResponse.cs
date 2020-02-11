using Shopy.Core.Domain.Entitties;
using Shopy.Application.Models;

namespace Shopy.Application.Products.Get
{
    public class GetProductResponse : Response<ProductResponse, Product>
    {
        public GetProductResponse(Product domainModel) : base(domainModel)
        { }
    }
}