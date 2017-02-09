using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using EF.Model;

namespace SportSquare.Data.Contracts
{
    public interface ISportSquareDbContext
    {
        IDbSet<Venue> Venues { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;


        void SaveChanges();
    }
}
