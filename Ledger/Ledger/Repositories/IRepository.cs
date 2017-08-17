using System;
using System.Linq;
using System.Linq.Expressions;

namespace Ledger.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {

        IUnitOfWork UnitOfWork { get; set; }

        void Create(TEntity entity);

        IQueryable<TEntity> GetAllData();

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter);

        TEntity GetSingle(Expression<Func<TEntity, bool>> filter);

        void Remove(TEntity entity);

        void Commit();

    }
}
