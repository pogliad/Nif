using System.Collections.Generic;
using System.Threading.Tasks;
using Nif.Data.Specification;

namespace Nif.Data.Repository
{
    public interface IRepository<TEntity, in TKey> where TEntity : EntityBase<TKey>
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync();
        CollectionPage<TEntity> GetAllPerPage(int pageNumber, int itemsPerPage);

        Task<TEntity> FindSingleAsync(ISpecification<TEntity> criteria);
        Task<IEnumerable<TEntity>> FindManyAsync(ISpecification<TEntity> criteria);
    }
}