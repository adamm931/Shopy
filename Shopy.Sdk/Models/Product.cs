﻿using Shopy.Sdk.Common;
using Shopy.Sdk.Images;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Sdk.Models
{
    public class Product : IHasImageSetup<Product>
    {
        public Guid Uid { get; set; }
        public string Caption { get; set; }
        public long ProductId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Brand Brand { get; set; }
        public IEnumerable<Size> Sizes { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public Image Image1 { get; set; }
        public Image Image2 { get; set; }
        public Image Image3 { get; set; }

        public async Task<Product> SetUpImages(ImageProvider imageProvider)
        {
            Image1 = new Image(await imageProvider.GetImageUrl(Uid, SdkSettingsHelper.Image1Name));
            Image2 = new Image(await imageProvider.GetImageUrl(Uid, SdkSettingsHelper.Image2Name));
            Image3 = new Image(await imageProvider.GetImageUrl(Uid, SdkSettingsHelper.Image3Name));
            return this;
        }
    }
}