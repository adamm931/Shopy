using Shopy.Core.Data.Entities;
using Shopy.Core.Models;
using System;

namespace Shopy.Core.Mappers
{
    public class SizeMapper : IMapper<Size, SizeTypeEF>
    {
        public Size FromEF(SizeTypeEF efEntity)
        {
            return new Size()
            {
                Caption = efEntity.Caption,
                EId = efEntity.SizeTypeEID
            };
        }

        public SizeTypeEF ToEF<TSoure>(Size model)
        {
            throw new NotImplementedException();
        }
    }
}