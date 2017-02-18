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
        private ICommentService commentService;
        private IVenueService service;
        public SearchPresenter(ISearchView view, IVenueService service, ICommentService commentService) : base(view)
        {
            this.View.QueryEvent += View_QueryEvent;
            if (service == null)
            {
                throw new ArgumentNullException(nameof(service));
            }
            this.service = service;
            this.commentService = commentService;
        }

        private void View_QueryEvent(object sender, SearchEventArgs e)
        {
            //commentService.CreateComment(6, 1, "Maliiiiiiiiii");
            var filter = e.Filter;
            var locationFilter = e.LocationFilter;
            var venues=this.service.FilterVenues(filter, locationFilter);
            this.View.Model.FilteredVenues = venues;
        }
    }
}