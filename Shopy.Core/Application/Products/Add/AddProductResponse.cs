using Shopy.Core.Models;

namespace Shopy.Core.Application.Products.Add
{
    public class AddProductResponse : Response<Product>
    {
        public AddProductResponse(Product result) : base(result)
        { }
    }
}