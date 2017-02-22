using System;

using SportSquare.Data.Contracts;

namespace SportSquare.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ISportSquareDbContext dbContext;

        public UnitOfWork(ISportSquareDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("DbContext can't be null");
            }

            this.dbContext = dbContext;
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
