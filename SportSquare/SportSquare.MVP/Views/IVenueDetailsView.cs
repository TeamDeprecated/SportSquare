using SportSquare.MVP.Models.VenueDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace SportSquare.MVP.Views
{
    public interface  IVenueDetailsView:IView<VenueDetailsViewModel>
    {
        event EventHandler<GetVenueDetailsEventArgs> OnFormGetItems;
    }
}