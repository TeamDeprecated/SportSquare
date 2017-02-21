using SportSquare.Models;
using SportSquare.MVP.Models.Search;
using SportSquare.MVP.Views;
using SportSquare.Services;
using SportSquare.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace SportSquare.MVP.Presenters
{

    public class SearchPresenter : Presenter<ISearchView>
    {
        private IVenueService venueService;
        private IWishListService  wishListService;

        public SearchPresenter(ISearchView view, IVenueService venueService, IWishListService wishListService) : base(view)
        {
            if (venueService == null)
            {
                throw new ArgumentNullException(nameof(venueService));
            }
            this.venueService = venueService;

            if (wishListService == null)
            {
                throw new ArgumentNullException(nameof(wishListService));
            }
            this.wishListService = wishListService;
            this.View.QueryEvent += View_QueryEvent;
            this.View.SaveVenueEvent += View_SaveVenueEvent;
        }

        private void View_SaveVenueEvent(object sender, SaveVenueArgs e)
        {
            Guid user;
            Guid.TryParse(e.User, out user);
            int venue;
            int.TryParse(e.Venue, out venue);
            this.wishListService.UpdateWishList(user, venue);
        }

        private void View_QueryEvent(object sender, SearchEventArgs e)
        {
            var filter = e.Filter;
            var locationFilter = e.LocationFilter;
            var venues=this.venueService.FilterVenues(filter, locationFilter);
            this.View.Model.FilteredVenues = venues;
        }
    }
}