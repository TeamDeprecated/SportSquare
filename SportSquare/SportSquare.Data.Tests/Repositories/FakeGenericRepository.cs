using System.Data.Entity;

using SportSquare.Data.Contracts;
using SportSquare.Data.Repositories;
using SportSquare.Models.Contracts;

namespace SportSquare.Data.Tests.Repositories
{
    public class FakeGenericRepository : GenericRepository<IDbModel>
    {
        public FakeGenericRepository(ISportSquareDbContext dbContext) : base(dbContext)
        {
        }

        public ISportSquareDbContext BaseDbContext
        {
            get { return base.DbContext; }
        }

        public IDbSet<IDbModel> BaseDbSet
        {
            get { return base.DbSet; }
        }
    }
}