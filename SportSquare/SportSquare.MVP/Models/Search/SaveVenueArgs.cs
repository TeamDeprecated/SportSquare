using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportSquare.MVP.Models.Search
{
    public class SaveVenueArgs : EventArgs

    {
        public SaveVenueArgs(string user, string venue)
        {
            Guard.WhenArgument(user, nameof(user)).IsNull().Throw();
            this.User = user;
            Guard.WhenArgument(venue, nameof(venue)).IsNull().Throw();
            this.Venue = venue;

        }
        public string User { get; private set;}
        public string Venue { get; private set; }
    }
}