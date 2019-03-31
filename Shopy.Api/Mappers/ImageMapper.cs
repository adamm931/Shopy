using Shopy.Api.Data.Entities;
using Shopy.Api.Models;

namespace Shopy.Api.Mappers
{
    public class ImageMapper : IMapper<Image, ImageEF>
    {
        public Image FromEF(ImageEF efEntity)
        {
            return new Image()
            {
                Uid = efEntity.Uid,
                Name = efEntity.Name,
                Url = efEntity.Url
            };

        }

        public ImageEF ToEF<TSoure>(Image model)
        {
            return new ImageEF()
            {
                //Uid = model.Uid,
                Name = model.Name,
                Url = model.Url
            };
        }
    }
}