using System;
using System.Collections.Generic;

using SportSquare.Models.Contracts;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportSquare.Models
{
    public class UserWishVenue : IDbModel
    {
        // TODO: Must be added validations!
        private ICollection<Venue> venues;

        public UserWishVenue()
        {
            this.venues = new HashSet<Venue>();

        }
        public UserWishVenue(Guid user) : this()
        {
            this.UserId = user;
        }

        [Key,ForeignKey("User")]
        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Venue> Venues
        {
            get { return this.venues; }
            set { this.venues = value; }
        }

        public bool IsHidden { get; set; }
    }
}
