using Shopy.Core.Domain.Entitties;
using Shopy.Core.Models;

namespace Shopy.Application.Products.Get
{
    public class GetProductResponse : Response<ProductResponse, Product>
    {
        public GetProductResponse(Product domainModel) : base(domainModel)
        { }
    }
}