using System.Collections.Generic;

namespace EF.Model
{
    public class Rating
    {
        // TODO: Must be added validations!

        private ICollection<User> users;

        public Rating()
        {
            this.users = new HashSet<User>();
        }

        public int Id { get; set; }

        public int VenueId { get; set; }

        public int Rate { get; set; }

        public ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}
