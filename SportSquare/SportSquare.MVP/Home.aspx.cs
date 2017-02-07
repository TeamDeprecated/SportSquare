using SportSquare.MVP.Models;
using SportSquare.MVP.Presenters;
using SportSquare.MVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace SportSquare.MVP
{
    [PresenterBinding(typeof(HomePresenter))]
    public partial class Home : MvpPage<HomeViewModel>, IHomeView
    {
        public event EventHandler<HomeEventArgs> IpDetails;

        protected void Page_Load(object sender, EventArgs e)
        {
            var ip = this.Request.UserHostAddress;
            IpDetails?.Invoke(sender, new HomeEventArgs(ip));
            this.location.Value = this.Model.City;
        }

        protected void search_Click(object sender, EventArgs e)
        {
            var filter = this.filter.Value;
            var locationFilter = this.location.Value;
            this.Response.Redirect(string.Format("~/search?q={0}&location={1}", filter, locationFilter));
        }
    }
}