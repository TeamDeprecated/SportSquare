using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SportSquare.Services.Contracts
{
    public interface ISportSquareGenericService<T>
    {
        T GetById(object id);

        void Add(T item);

        void Update(T item);

        void Delete(T item);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter);

        IEnumerable<T> GetAll<T1>(
           Expression<Func<T, bool>> filter,
           Expression<Func<T, T1>> orderBy);

        IEnumerable<TResult> GetAll<T1, TResult>(
           Expression<Func<T, bool>> filter,
           Expression<Func<T, T1>> orderBy,
           Expression<Func<T, TResult>> select);

        IEnumerable<T> GetDeleted();
    }
}
