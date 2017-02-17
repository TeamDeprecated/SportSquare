using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

using SportSquare.Data.Contracts;
using SportSquare.Models.Contracts;

namespace SportSquare.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IDbModel
    {
        private ISportSquareDbContext dbContext;
        private IDbSet<TEntity> dbSet;

        public GenericRepository(ISportSquareDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("DbContext can't be null");
            }

            this.dbContext = dbContext;
            this.dbSet = this.DbContext.Set<TEntity>();

            if (this.dbSet == null)
            {
                throw new ArgumentException("This DbSet<{0}> doesn't exist in DbContext", typeof(TEntity).Name);
            }
        }

        private DbEntityEntry AttachIfDetached(TEntity entity)
        {
            var entry = this.DbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            return entry;
        }

        protected ISportSquareDbContext DbContext
        {
            get
            {
                return this.dbContext;
            }
        }

        protected IDbSet<TEntity> DbSet
        {
            get
            {
                return this.dbSet;
            }
        }

        public TEntity GetById(object id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("Id can't be null!");
            }

            return this.DbSet.Find(id);
        }

        public void Add(TEntity entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Added;
        }

        public void Update(TEntity entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Modified;
        }

        public void Hide(TEntity entity)
        {
            entity.IsHidden = true;

            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            var entry = AttachIfDetached(entity);
            entry.State = EntityState.Deleted;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.GetAll(null);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filterExpression)
        {
            if (filterExpression == null)
            {
                throw new ArgumentNullException("Filter can't be null!");
            }

            return this.GetAll<TEntity>(filterExpression, null);
        }

        public IEnumerable<TEntity> GetAll<T1>(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, T1>> sortExpression)
        {
            if (filterExpression == null)
            {
                throw new ArgumentNullException("Filter can't be null!");
            }

            if (sortExpression == null)
            {
                throw new ArgumentNullException("Sort can't be null!");
            }

            return this.GetAll<T1, TEntity>(filterExpression, sortExpression, null);
        }

        public IEnumerable<T2> GetAll<T1, T2>(Expression<Func<TEntity, bool>> filterExpression, 
            Expression<Func<TEntity, T1>> sortExpression, 
            Expression<Func<TEntity, T2>> selectExpression)
        {
            IQueryable<TEntity> result = this.DbSet;

            if (filterExpression != null)
            {
                result = result.Where(filterExpression);
            }

            if (sortExpression != null)
            {
                result = result.OrderBy(sortExpression);
            }

            if (selectExpression != null)
            {
                return result.Select(selectExpression).ToList();
            }
            else
            {
                return result.OfType<T2>().ToList();
            }
        }
    }
}
