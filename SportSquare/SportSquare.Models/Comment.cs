using System;
using System.Collections.Generic;

using SportSquare.Models.Contracts;

namespace SportSquare.Models
{
    public class Comment : IDbModel
    {
        // TODO: Must be added validations!

        private ICollection<User> users;

        public Comment()
        {
            this.users = new HashSet<User>();
        }
        public int Id { get; set; }

        public int VenueId { get; set; }

        public virtual Venue Venue { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public bool IsDeleted { get; set; }
    }
}
