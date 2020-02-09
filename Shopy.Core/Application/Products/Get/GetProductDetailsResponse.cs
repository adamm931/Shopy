using Shopy.Core.Models;

namespace Shopy.Core.Application.Products.Get
{
    public class GetProductDetailsResponse : Response<ProductDetailsResponse>
    {
        public GetProductDetailsResponse(ProductDetailsResponse result) : base(result)
        { }
    }
}