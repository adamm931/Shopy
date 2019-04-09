using Shopy.Proto.Images;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Proto.Models
{
    public class ProductDetails : IHasImageSetup<ProductDetails>
    {
        public Product Product { get; set; }

        public IEnumerable<Product> RelatedProducts { get; set; }

        public async Task<ProductDetails> SetUpImages(ImageProvider imageProvider)
        {
            await Product.SetUpImages(imageProvider);

            foreach (var product in RelatedProducts)
            {
                await product.SetUpImages(imageProvider);
            }

            return this;
        }
    }
}
