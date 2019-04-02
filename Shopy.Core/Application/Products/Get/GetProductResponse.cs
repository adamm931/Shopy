using Shopy.Core.Models;

namespace Shopy.Core.Application.Products.Get
{
    public class GetProductResponse : Response<Product>
    {
        public GetProductResponse(Product result) : base(result)
        { }
    }
}