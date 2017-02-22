using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SportSquare.Models.Contracts;

namespace SportSquare.Models
{
    public class UserWishVenue : IDbModel
    {
        private ICollection<Venue> venues;

        public UserWishVenue()
        {
            this.venues = new HashSet<Venue>();
            this.IsHidden = false;
        }

        public UserWishVenue(Guid user) : this()
        {
            this.UserId = user;
        }

        [Key, ForeignKey("User")]
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
