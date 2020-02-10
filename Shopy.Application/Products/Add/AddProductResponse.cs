using Shopy.Core.Domain.Entitties;
using Shopy.Core.Models;

namespace Shopy.Application.Products.Add
{
    public class AddProductResponse : Response<ProductResponse, Product>
    {
        public AddProductResponse(Product domainModel) : base(domainModel)
        { }
    }
}