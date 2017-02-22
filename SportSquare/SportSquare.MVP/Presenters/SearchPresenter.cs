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
using SportSquare.MVP.Models.VenueDetails;

namespace SportSquare.MVP.Presenters
{

    public class SearchPresenter : Presenter<ISearchView>
    {
        private IVenueService venueService;
        private IWishListService wishListService;
        private IRatingService ratingService;

        public SearchPresenter(ISearchView view, IVenueService venueService, IWishListService wishListService, IRatingService ratingService) : base(view)
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
            if (ratingService == null)
            {
                throw new ArgumentNullException(nameof(ratingService));
            }
            this.wishListService = wishListService;
            this.ratingService = ratingService;
            this.View.QueryEvent += View_QueryEvent;
            this.View.SaveVenueEvent += View_SaveVenueEvent;
            this.View.UpdateRating += View_UpdateRating;

        }

        private void View_UpdateRating(object sender, UpdateRatingEventArgs e)
        {
            this.ratingService.AddRating(this.ParseGuid(e.UserID), this.ParseId(e.VenueId), ParseId(e.RatingNew));

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
            var venues = this.venueService.FilterVenues(filter, locationFilter);
            this.View.Model.FilteredVenues = venues;
        }
        private Guid ParseGuid(string id)
        {
            Guid parsedId;
            Guid.TryParse(id, out parsedId);
            return parsedId;
        }
        private int ParseId(string id)
        {
            int parsedID;
            int.TryParse(id, out parsedID);
            return parsedID;
        }
    }
}