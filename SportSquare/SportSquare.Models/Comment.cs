using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Model
{
    public class Comment
    {
        // TODO: Must be added validations!

        private ICollection<User> users;

        public Comment()
        {
            this.users = new HashSet<User>();
        }
        public int Id { get; set; }

        public int VenueId { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}
