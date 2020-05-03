using Newtonsoft.Json;
using Shopy.Core.Domain.Entitties.Enumerations;
using System;
using System.Collections.Generic;
using System.Web;

namespace Shopy.Sdk.Models
{
    public class AddEditProduct
    {
        public Guid Uid { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public BrandTypeId Brand { get; set; }

        public IEnumerable<SizeTypeId> Sizes { get; set; }

        [JsonIgnore]
        public HttpPostedFileBase Image1 { get; set; }

        [JsonIgnore]
        public HttpPostedFileBase Image2 { get; set; }

        [JsonIgnore]
        public HttpPostedFileBase Image3 { get; set; }
    }
}
