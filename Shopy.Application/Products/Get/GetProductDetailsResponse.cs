using Shopy.Core.Domain.Entitties;
using Shopy.Core.Models;

namespace Shopy.Application.Products.Get
{
    public class GetProductDetailsResponse : Response<ProductDetailsResponse, Product>
    {
        public GetProductDetailsResponse(Product domainModel) : base(domainModel)
        { }
    }
}