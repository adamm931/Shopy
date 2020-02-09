using Shopy.Core.Models;

namespace Shopy.Core.Application.Products.Get
{
    public class GetProductResponse : Response<ProductReponse>
    {
        public GetProductResponse(ProductReponse result) : base(result)
        { }
    }
}