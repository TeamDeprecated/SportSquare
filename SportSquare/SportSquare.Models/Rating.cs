using System.Collections.Generic;

using SportSquare.Models.Contracts;

namespace SportSquare.Models
{
    public class Rating : IDbModel
    {
        // TODO: Must be added validations!

        private ICollection<User> users;

        public Rating()
        {
            this.users = new HashSet<User>();
        }

        public int Id { get; set; }

        public int Rate { get; set; }

        public int VenueId { get; set; }

        public virtual Venue Venue { get; set; }

        public ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }

        public bool IsDeleted { get; set; }
    }
}
