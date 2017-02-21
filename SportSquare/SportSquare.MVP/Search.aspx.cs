using SportSquare.MVP.Views;
using System;
using System.Linq;
using WebFormsMvp.Web;
using WebFormsMvp;
using SportSquare.MVP.Models.Search;
using SportSquare.MVP.Presenters;
using GoogleMaps.Markers;

namespace SportSquare.MVP
{
    [PresenterBinding(typeof(SearchPresenter))]
    public partial class Search : MvpPage<SearchViewModel>, ISearchView
    {

        public event EventHandler<SearchEventArgs> QueryEvent;

        protected void Page_Load(object sender, EventArgs e)
        {
            string filter = string.Empty;
            string locationFilter = string.Empty;

            if (this.Request.QueryString.Count < 1)
            {
                this.QueryEvent?.Invoke(sender, new SearchEventArgs(filter, locationFilter));
                return;
            }

            filter = this.Request.QueryString.GetValues("q")[0];
            locationFilter = this.Request.QueryString.GetValues("location")[0];
            this.QueryEvent?.Invoke(sender, new SearchEventArgs(filter, locationFilter));
            var firstVenue = this.Model.FilteredVenues.First();

            if (firstVenue != null)
            {
                this.GoogleMap1.Center.Latitude = firstVenue.Latitude;
                this.GoogleMap1.Center.Longitude = firstVenue.Longitude;

            }

            var index = 1;
            foreach (var item in this.Model.FilteredVenues)
            {
                var marker = new Marker();
                marker.Position.Latitude = item.Latitude;
                marker.Position.Longitude = item.Longitude;
                marker.Clickable = true;
                marker.Info = item.Title;
                marker.LabelText = index.ToString();
                this.GoogleMap1.Markers.Add(marker);
                this.Markers.Markers.Add(marker);
                index++;
            }

        }

    }
}