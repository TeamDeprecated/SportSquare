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
            //TODO validate querystringRequest!!!!
            var filter = this.Request.QueryString.GetValues(0)[0];
            var locationFilter = this.Request.QueryString.GetValues(1)[0];
            this.QueryEvent?.Invoke(sender, new SearchEventArgs(filter, locationFilter));
        }
    }
}