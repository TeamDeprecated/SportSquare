using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportSquare.MVP.Models.VenueDetails
{
    public class AddCommentEventArgs: GenericVenueDetailsEventArgs
    {
        public AddCommentEventArgs(string userId, string venueId, string comment):base(userId, venueId)
        {
         
            this.Comment = comment;
        }
        public string Comment { get; private set; }

    }
}