using SportSquare.MVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp.Web;
using SportSquare.MVP.Models;
using WebFormsMvp;
using SportSquare.MVP.Models.Search;

namespace SportSquare.MVP
{
    public partial class Search : MvpPage<SearchViewModel>, ISearchView
    {
        
        public event EventHandler<SearchEventArgs> QueryEvent;

        protected void Page_Load(object sender, EventArgs e)
        {
            string filter = string.Empty;
            string locationFilter = string.Empty;
            if (this.Request.QueryString.Count < 1 )
            {
                this.QueryEvent?.Invoke(sender, new SearchEventArgs(filter, locationFilter));
                return;
            }
             filter = this.Request.QueryString.GetValues("q")[0];
            locationFilter = this.Request.QueryString.GetValues("location")[0];
            this.QueryEvent?.Invoke(sender, new SearchEventArgs(filter, locationFilter));
            this.FilteredVenues.DataSource = Model.FilteredVenues;
            this.FilteredVenues.DataBind();
        }
        protected void SaveButton_Click( object sender, EventArgs e)
        {

        }
    }
}