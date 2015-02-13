using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Nif.Data.Specification;
using Nif.Extensions;

namespace Nif.Data.Repository
{
    public class GenericRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : EntityBase<TKey>
    {
        protected readonly DbContext _context;
        protected readonly IDbSet<TEntity> _set;


        public GenericRepository(DbContext context)
        {
            Contract.Requires<ArgumentNullException>(context.IsNotNull());

            _context = context;
            _set = _context.Set<TEntity>();
        }


        public virtual void Create(TEntity entity)
        {
            Contract.Requires<ArgumentNullException>(entity.IsNotNull());

            _set.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            Contract.Requires<ArgumentNullException>(entity.IsNotNull());

            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            Contract.Requires<ArgumentNullException>(entity.IsNotNull());

            _context.Entry(entity).State = EntityState.Deleted;
        }


        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _set.ToListAsync();
        }

        public virtual CollectionPage<TEntity> GetAllPerPage(int pageNumber, int itemsPerPage)
        {
            Contract.Requires<ArgumentException>(pageNumber > 0);
            Contract.Requires<ArgumentException>(itemsPerPage > 0);

            var collectionPage = new CollectionPage<TEntity>
                {
                    ItemsPerPage = itemsPerPage,
                    TotalItems = _set.Count(),
                    CurrentPage = pageNumber
                };
            collectionPage.Items = collectionPage.HasItemsOnRequestedPage
                ? _set
                    .OrderBy(entity => entity.Id)
                    .Skip((pageNumber - 1) * itemsPerPage)
                    .Take(itemsPerPage).ToList()
                : null;

            return collectionPage;
        }


        public virtual async Task<TEntity> FindSingleAsync(ISpecification<TEntity> criteria)
        {
            Contract.Requires<ArgumentNullException>(criteria.IsNotNull());

            return await _set
                .SingleOrDefaultAsync(criteria.Predicate);
        }

        public virtual async Task<IEnumerable<TEntity>> FindManyAsync(ISpecification<TEntity> criteria)
        {
            Contract.Requires<ArgumentNullException>(criteria.IsNotNull());

            if (_set.Local.Any())
            {
                var entities = await _set.Local
                    .Where(criteria.IsSatisfiedBy)
                    .AsQueryable()
                    .ToListAsync();

                if (entities.IsNotNull())
                {
                    return entities;
                }
            }

            return await _set
                .Where(criteria.Predicate)
                .ToListAsync();
        }
    }
}