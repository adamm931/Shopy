using Shopy.Core.Models;

namespace Shopy.Core.Application.Products.Queries
{
    public class GetProductResponse : Response<Product>
    {
        public GetProductResponse(Product result) : base(result)
        { }
    }
}