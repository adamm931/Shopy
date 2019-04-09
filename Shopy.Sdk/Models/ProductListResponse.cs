﻿using Shopy.SDK.Images;
using System.Threading.Tasks;

namespace Shopy.SDK.Models
{
    public class ProductListResponse : ListResponse<Product>, IHasImageSetup<ProductListResponse>
    {
        public int TotalRecords { get; set; }

        public async Task<ProductListResponse> SetUpImages(ImageProvider imageProvider)
        {
            foreach (var product in Result)
            {
                await product.SetUpImages(imageProvider);
            }

            return this;
        }
    }
}
