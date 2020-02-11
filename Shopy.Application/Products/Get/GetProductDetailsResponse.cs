using Shopy.Core.Domain.Entitties;
using Shopy.Application.Models;

namespace Shopy.Application.Products.Get
{
    public class GetProductDetailsResponse : Response<ProductDetailsResponse, Product>
    {
        public GetProductDetailsResponse(Product domainModel) : base(domainModel)
        { }
    }
}