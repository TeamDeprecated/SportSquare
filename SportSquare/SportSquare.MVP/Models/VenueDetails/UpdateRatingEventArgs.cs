﻿using System;

namespace SportSquare.MVP.Models.VenueDetails
{
    public class UpdateRatingEventArgs:GenericVenueDetailsEventArgs
    {
        public UpdateRatingEventArgs(string user, string venueId, string rating):base(user, venueId)
        {
        
            this.RatingNew = rating;
        }

        public string RatingNew { get; private set; }
    }
}