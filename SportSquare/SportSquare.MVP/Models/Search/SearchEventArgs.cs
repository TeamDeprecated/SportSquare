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
            this.Filter = string.IsNullOrEmpty(filter) ? string.Empty: filter;

            this.LocationFilter = string.IsNullOrEmpty(locationFilter) ? string.Empty : locationFilter;
        }
    }
}