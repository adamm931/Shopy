using Shopy.Core.Models;

namespace Shopy.Core.Application.Products.Get
{
    public class GetProductDetailsResponse : Response<ProductDetails>
    {
        public GetProductDetailsResponse(ProductDetails result) : base(result)
        { }
    }
}