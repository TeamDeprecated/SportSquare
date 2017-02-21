using Bytes2you.Validation;
using SportSquare.MVP.Models.VenueDetails;
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
    public class VenueDetailsPresenter : Presenter<IVenueDetailsView>
    {
        private IVenueService venueService;
        private ICommentService commentService;
        private IRatingService ratingService;

        public VenueDetailsPresenter(IVenueDetailsView view, IVenueService venueService, ICommentService commentService, IRatingService ratingService) : base(view)
        {
            Guard.WhenArgument(venueService, nameof(venueService)).IsNull().Throw();
            Guard.WhenArgument(commentService, nameof(commentService)).IsNull().Throw();
            Guard.WhenArgument(ratingService, nameof(ratingService)).IsNull().Throw();
            this.venueService = venueService;
            this.commentService = commentService;
            this.ratingService = ratingService;
            this.View.OnFormGetItems += View_OnFormGetItems;
            this.View.UpdateRating += View_UpdateRating;
            this.View.AddComment += View_AddComment;
        }

        private void View_AddComment(object sender, AddCommentEventArgs e)
        {
            this.commentService.CreateComment(e.UserID, e.VenueId, e.Comment);
            this.View.Model.Venue = this.venueService.GetVenue(e.VenueId);

        }

        private void View_UpdateRating(object sender, UpdateRatingEventArgs e)
        {
           
            this.ratingService.AddRating(e.UserID, e.VenueId, ParseId(e.RatingNew));
        }

        private void View_OnFormGetItems(object sender, GetVenueDetailsEventArgs e)
        {
            
            this.View.Model.Venue= this.venueService.GetVenue(e.Id);
        }
        private int ParseId(string id)
        {
            int rate;
            int.TryParse(id, out rate);
            return rate;
        }
    }
}