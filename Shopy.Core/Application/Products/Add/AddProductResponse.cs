using Shopy.Core.Models;

namespace Shopy.Core.Application.Products.Add
{
    public class AddProductResponse : Response<ProductReponse>
    {
        public AddProductResponse(ProductReponse result) : base(result)
        { }
    }
}