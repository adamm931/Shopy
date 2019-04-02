﻿namespace Shopy.Core.Mappers
{
    public interface IMapper<TModel, TEfEntity>
    {
        TModel FromEF(TEfEntity efEntity);

        TEfEntity ToEF<TSoure>(TModel model);

    }
}