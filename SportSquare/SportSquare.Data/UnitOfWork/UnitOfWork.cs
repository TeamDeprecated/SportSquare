using System;

using SportSquare.Data.Contracts;

namespace SportSquare.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ISportSquareDbContext dbContext;

        public UnitOfWork(ISportSquareDbContext dbContext)
        {
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
