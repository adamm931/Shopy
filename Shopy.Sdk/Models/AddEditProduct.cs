using Newtonsoft.Json;
using Shopy.SDK.Common;
using Shopy.SDK.Images;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace Shopy.SDK.Models
{
    public class AddEditProduct : ISavesImage
    {
        public Guid Uid { get; set; }
        public string Caption { get; set; }
        public long ProductId { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public IEnumerable<string> Sizes { get; set; }

        [JsonIgnore]
        public HttpPostedFileBase Image1 { get; set; }

        [JsonIgnore]
        public HttpPostedFileBase Image2 { get; set; }

        [JsonIgnore]
        public HttpPostedFileBase Image3 { get; set; }

        public async Task SaveImageAsync(ImageProvider imageProvider)
        {
            await imageProvider.SaveImageAsync(Image1, Uid, SDKSettingsHelper.Image1Name);
            await imageProvider.SaveImageAsync(Image2, Uid, SDKSettingsHelper.Image2Name);
            await imageProvider.SaveImageAsync(Image3, Uid, SDKSettingsHelper.Image3Name);
        }
    }
}
