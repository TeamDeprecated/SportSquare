using System.Data.Entity;

using SportSquare.Models;
using SportSquare.Data.Contracts;

namespace SportSquare.Data
{
    public class SportSquareDbContext : DbContext, ISportSquareDbContext
    {
     
        public SportSquareDbContext()
            : base("SportSquareDbContext")
        {
        }

        public virtual IDbSet<Venue> Venues { get; set; }

        public virtual IDbSet<VenueType> VenueTypes { get; set; }

        public virtual IDbSet<Rating> Ratings { get; set; }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<UserWishVenue> UserWishVenues { get; set; }

        public virtual IDbSet<UserFavoriteVenue> UserFavoriteVenues { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        void ISportSquareDbContext.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}