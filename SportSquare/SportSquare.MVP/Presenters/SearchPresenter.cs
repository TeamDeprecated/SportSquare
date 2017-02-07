using SportSquare.MVP.Models.Search;
using SportSquare.MVP.Views;
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
        public SearchPresenter(ISearchView view, ISearchService service) : base(view)
        {
            this.View.QueryEvent += View_QueryEvent;
        }

        private void View_QueryEvent(object sender, SearchEventArgs e)
        {
            var filter = e.Filter;
            var locationFilter = e.LocationFilter;
        }
    }
}