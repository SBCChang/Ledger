using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Ledger.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        #region Field

        private DbSet<TEntity> _entity;

        #endregion

        #region Constructor

        public Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        #endregion

        #region Property

        public DbSet<TEntity> Entity
        {
            get
            {
                if (_entity == null)
                {
                    _entity = UnitOfWork.DbContext.Set<TEntity>();
                }
                return _entity;
            }
        }

        public IUnitOfWork UnitOfWork { get; set; }

        #endregion

        #region Method

        public void Commit()
        {
            UnitOfWork.Save();
        }

        public void Create(TEntity entity)
        {
            Entity.Add(entity);
        }

        public IQueryable<TEntity> GetAllData()
        {
            return Entity;
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> filter)
        {
            return Entity.SingleOrDefault(filter);
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter)
        {
            return Entity.Where(filter);
        }

        public void Remove(TEntity entity)
        {
            Entity.Remove(entity);
        }

        #endregion

    }
}