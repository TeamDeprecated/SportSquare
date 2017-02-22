using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using SportSquare.Models.Contracts;

namespace SportSquare.Data.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : class, IDbModel
    {
        TEntity GetById(object id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Hide(TEntity entity);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filterExpression);

        IEnumerable<TEntity> GetAll<T1>(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, T1>> sortExpression);

        IEnumerable<T2> GetAll<T1, T2>(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, T1>> sortExpression, Expression<Func<TEntity, T2>> selectExpression);
    }
}
