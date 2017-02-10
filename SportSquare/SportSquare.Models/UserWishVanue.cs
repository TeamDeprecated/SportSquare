using System.Collections.Generic;

namespace EF.Model
{
    public class UserWishVanue
    {
        // TODO: Must be added validations!

        private ICollection<User> users;

        public UserWishVanue()
        {
            this.users = new HashSet<User>();
        }

        public int Id { get; set; }

        public int VenueId { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}
