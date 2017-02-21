using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportSquare.MVP.Models.VenueDetails
{
    public class StringEventArgs : EventArgs
    {

        public StringEventArgs()
        {
        }

        public StringEventArgs(string stringParameter)
        {
            this.StringParameter = stringParameter;
        }

        public string StringParameter { get; set; }
    }
}