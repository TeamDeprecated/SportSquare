using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SportSquare.Data.Contracts;
using SportSquare.Models.Contracts;
using SportSquare.Services.Contracts;

namespace SportSquare.Services
{
    public abstract class SportSquareGenericService<TEntity> : ISportSquareGenericService<TEntity> where TEntity: class, IDbModel
    {
        private readonly IGenericRepository<TEntity> repository;
        private readonly IUnitOfWork unitOfWork;

        public SportSquareGenericService(IGenericRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("Repository cannot be null!");
            }

            if (unitOfWork == null)
            {
                throw new ArgumentNullException("UnitOfWork cannot be null!");
            }

            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        protected IUnitOfWork UnitOfWork
        {
            get
            {
                return this.unitOfWork;
            }
        }

        public void Add(TEntity entity)
        {
            this.repository.Add(entity);

            using (this.UnitOfWork)
            {
                this.UnitOfWork.Commit();
            }
        }

        public void Update(TEntity entity)
        {
            this.repository.Update(entity);

            using (this.UnitOfWork)
            {
                this.UnitOfWork.Commit();
            }
        }

        public void Delete(TEntity entity)
        {
            this.repository.Delete(entity);

            using (this.UnitOfWork)
            {
                this.UnitOfWork.Commit();
            }
        }

        public TEntity GetById(object id)
        {
            if ((int)id < 0)
            {
                throw new ArgumentNullException("Id can't be negative!");
            }

            if (id == null)
            {
                throw new ArgumentNullException("Id can't be null!");
            }

            return this.repository.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.repository.GetAll();
        }

        public IEnumerable<TEntity> GetDeleted()
        {
            return this.GetAll(ent => ent.IsDeleted);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("Filter can't be null");
            }

            return this.repository.GetAll(filter);
        }

        public IEnumerable<TEntity> GetAll<T1>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, T1>> orderBy)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("Filter can't be null");
            }

            if (orderBy == null)
            {
                throw new ArgumentNullException("OrderBy can't be null");
            }

            return this.repository.GetAll(filter, orderBy);
        }

        public IEnumerable<TResult> GetAll<T1, TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, T1>> orderBy, Expression<Func<TEntity, TResult>> select)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("Filter can't be null");
            }

            if (orderBy == null)
            {
                throw new ArgumentNullException("OrderBy can't be null");
            }

            if (select == null)
            {
                throw new ArgumentNullException("Select can't be null");
            }

            return this.repository.GetAll(filter, orderBy, select);
        }
    }
}
