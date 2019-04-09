using Newtonsoft.Json;
using Shopy.Proto.Common;
using Shopy.Proto.Images;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace Shopy.Proto.Models
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
            await imageProvider.SaveImageAsync(Image1, Uid, ProtoSettingsHelper.Image1Name);
            await imageProvider.SaveImageAsync(Image2, Uid, ProtoSettingsHelper.Image2Name);
            await imageProvider.SaveImageAsync(Image3, Uid, ProtoSettingsHelper.Image3Name);
        }
    }
}
