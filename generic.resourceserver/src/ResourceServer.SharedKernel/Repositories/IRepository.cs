using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ResourceServer.SharedKernel.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IList<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        bool Add(TEntity entity);

        bool Delete(TEntity entity);

        bool Update(TEntity entity);

        bool IsValid(TEntity entity);

        void Save();
    }
}