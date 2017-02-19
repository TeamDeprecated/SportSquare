using Bytes2you.Validation;
using SportSquare.MVP.Models.VenueDetails;
using SportSquare.MVP.Views;
using SportSquare.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace SportSquare.MVP.Presenters
{
    public class VenueDetailsPresenter : Presenter<IVenueDetailsView>
    {
        private IVenueService service;

        public VenueDetailsPresenter(IVenueDetailsView view, IVenueService service) : base(view)
        {
            Guard.WhenArgument(service, nameof(service)).IsNull().Throw();
            this.service = service;
            this.View.OnFormGetItems += View_OnFormGetItems;
        }

        private void View_OnFormGetItems(object sender, GetVenueDetailsEventArgs e)
        {
            this.View.Model.Venue= this.service.GetVenue(e.Id);
        }
    }
}