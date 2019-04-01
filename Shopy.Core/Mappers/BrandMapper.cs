using Shopy.Core.Data.Entities;
using Shopy.Core.Models;

namespace Shopy.Core.Mappers
{
    public class BrandMapper : IMapper<Brand, BrandTypeEF>
    {
        public Brand FromEF(BrandTypeEF efEntity)
        {
            return new Brand()
            {
                Caption = efEntity.Caption,
                EId = efEntity.BrandTypeEId
            };
        }

        public BrandTypeEF ToEF<TSoure>(Brand model)
        {
            return new BrandTypeEF()
            {
                Caption = model.Caption,
                BrandTypeEId = model.EId
            };
        }
    }
}