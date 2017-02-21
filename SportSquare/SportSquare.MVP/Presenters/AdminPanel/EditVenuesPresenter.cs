using SportSquare.MVP.Views.AdminPanel;
using SportSquare.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;
using SportSquare.MVP.Models.Search;
using SportSquare.MVP.Models.AdminPanel;
using SportSquare.MVP.Models.VenueDetails;

namespace SportSquare.MVP.Presenters.AdminPanel
{
    public class EditVenuesPresenter : Presenter<IEditVenuesView>
    {
        private IVenueService service;

        public EditVenuesPresenter(IEditVenuesView view, IVenueService service) : base(view)
        {
            if (service == null)
            {
                throw new ArgumentNullException("Venue service can't be null!");
            }
            this.View.QueryEvent += View_QueryEvent;
            this.View.VenueDetailsId += View_GetVenuesById;
            this.service = service;
        }

        private void View_GetVenuesById(object sender, StringEventArgs e)
        {
            int id;
            int.TryParse(e.StringParameter.ToString(), out id);

            this.View.Model.Venue = this.service.GetVenue(id);
        }

        private void View_QueryEvent(object sender, SearchEventArgs e)
        {
            var filter = e.Filter;
            var locationFilter = e.LocationFilter;
            var venues = this.service.FilterVenues(filter, locationFilter);
            this.View.Model.FilteredVenues = venues;
        }
    }
}