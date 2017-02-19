using SportSquare.MVP.Models.VenueDetails;
using SportSquare.MVP.Presenters;
using SportSquare.MVP.Views;
using SportSquareDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace SportSquare.MVP
{
    [PresenterBinding(typeof(VenueDetailsPresenter))]

    public partial class VenueDetails : MvpPage<VenueDetailsViewModel>, IVenueDetailsView
    {
        public event EventHandler<GetVenueDetailsEventArgs> OnFormGetItems;



        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public VenueDetailedDTO FormViewVenueDetails_GetItem([QueryString] int? id)
        {
            this.OnFormGetItems?.Invoke(this, new GetVenueDetailsEventArgs(id));

            return this.Model.Venue;
        }

        protected void VenueRating_Changed(object sender, AjaxControlToolkit.RatingEventArgs e)
        {

        }
    }
}