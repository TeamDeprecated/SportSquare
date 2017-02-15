using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using SportSquare.Models;

namespace SportSquare.Data.Contracts
{
    public interface ISportSquareDbContext
    {
        IDbSet<Venue> Venues { get; set; }

        IDbSet<VenueType> VenueTypes { get; set; }

        IDbSet<Rating> Ratings { get; set; }

        IDbSet<User> Users { get; set; }

        IDbSet<UserWishVenue> UserWishVenues { get; set; }

        IDbSet<UserFavoriteVenue> UserFavoriteVenues { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();
    }
}
