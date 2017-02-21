using System.Collections.Generic;

using SportSquare.Models.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace SportSquare.Models
{
    public class Rating : IDbModel
    {
        // TODO: Must be added validations!

        public Rating()
        {
            this.IsHidden = false;
        }

        public Rating(Guid user, int venueId, int rate) : this()
        {
            this.UserId= user;
            this.VenueId = venueId;
            this.Rate = rate;
        }

        public int Id { get; set; }

        public int Rate { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public int VenueId { get; set; }

        public virtual Venue Venue { get; set; }

        public bool IsHidden { get; set; }
    }
}
