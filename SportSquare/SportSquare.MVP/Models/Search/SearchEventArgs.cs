using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportSquare.MVP.Models.Search
{
    public class SearchEventArgs:EventArgs
    {
        public string Filter { get; private set; }
        public string LocationFilter { get; private set; }
        public SearchEventArgs(string filter, string locationFilter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                this.Filter = string.Empty;
            }
            else
            {
                this.Filter = filter;
            }
            if (string.IsNullOrEmpty(locationFilter))
            {
                this.LocationFilter = string.Empty;
            }
            else
            {
                this.LocationFilter = locationFilter;

            }
        }
    }
}