using SportSquare.Data.Contracts;
using System;

namespace SportSquare.Data
{
    public class UnitOfWork:IUnitOfWork, IDisposable
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
