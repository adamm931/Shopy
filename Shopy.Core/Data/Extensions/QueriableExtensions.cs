using Shopy.Core.Domain.Entitties.Base;
using Shopy.Core.Domain.Entitties.Interfaces;
using Shopy.Core.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Shopy.Core.Data.Extensions
{
    public static class QueriableExtensions
    {
        public static async Task<TEntity> ByUidAsync<TEntity>(this IQueryable<TEntity> table, Guid uid)
            where TEntity : class, IUid
        {
            var entity = await table.SingleOrDefaultAsync(entity => entity.Uid == uid);

            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(TEntity), uid);
            }

            return entity;
        }

        public static async Task<TEntity> ByEnumIdAsync<TEntity, TId>(this IQueryable<TEntity> table, TId id)
           where TEntity : EnumEntity<TId>
           where TId : Enum
        {
            var entity = await table.SingleOrDefaultAsync(entity => entity.Id.ToString() == id.ToString());

            if (entity == null)
            {
                throw new EntityNotFoundException<TId>(nameof(TEntity), id);
            }

            return entity;
        }

        public static async Task<IQueryable<TEntity>> ByEnumIdsAsync<TEntity, TId>(this IQueryable<TEntity> table, IEnumerable<TId> ids)
           where TEntity : EnumEntity<TId>
           where TId : Enum
        {
            return await Task.Run(() => table.Where(entity => ids.Contains(entity.Id)));
        }

        public static void AddRange<TEntity>(this IDbSet<TEntity> dbSet, IEnumerable<TEntity> entitiesToAdd)
            where TEntity : class
        {
            foreach (var item in entitiesToAdd)
            {
                dbSet.Add(item);
            }
        }
    }
}
