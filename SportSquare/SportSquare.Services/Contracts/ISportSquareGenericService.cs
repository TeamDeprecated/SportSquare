using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SportSquare.Services.Contracts
{
    public interface ISportSquareGenericService<T>
    {
        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Hide(T entity);

        void Delete(T entity);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter);

        IEnumerable<T> GetAll<T1>(
           Expression<Func<T, bool>> filter,
           Expression<Func<T, T1>> orderBy);

        IEnumerable<TResult> GetAll<T1, TResult>(
           Expression<Func<T, bool>> filter,
           Expression<Func<T, T1>> orderBy,
           Expression<Func<T, TResult>> select);

        IEnumerable<T> GetHidden();
    }
}
