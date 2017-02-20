using System.Collections.Generic;

using SportSquare.Models.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace SportSquare.Models
{
    public class Rating : IDbModel
    {
        // TODO: Must be added validations!

        private ICollection<User> users;

        public Rating()
        {
        }

        public Rating(Guid user, int venueId, int rate)
        {
            this.UserId= user;
            this.VenueId = venueId;
            this.Rate = rate;
        }

        public int Id { get; set; }

        public int Rate { get; set; }

        //[Key]
        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        //[Key]
        public int VenueId { get; set; }

        public virtual Venue Venue { get; set; }

        public bool IsHidden { get; set; }
    }
}
