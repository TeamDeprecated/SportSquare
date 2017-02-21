using SportSquare.MVP.Models;
using SportSquare.MVP.Presenters;
using SportSquare.MVP.Views;
using System;
using WebFormsMvp;
using WebFormsMvp.Web;
using Microsoft.AspNet.Identity;


namespace SportSquare.MVP
{
    [PresenterBinding(typeof(HomePresenter))]
    public partial class Home : MvpPage<HomeViewModel>, IHomeView
    {
        public event EventHandler<HomeEventArgs> IpDetails;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var ip = this.Request.UserHostAddress;
                IpDetails?.Invoke(sender, new HomeEventArgs(ip));
                this.location.Value = this.Model.City;

            }
        }
  
        protected void Search_Click(object sender, EventArgs e)
        {
            var filter = this.filter.Value;
            if (string.IsNullOrEmpty(this.location.Value))
            {
                this.location.Value = this.Model.City;
            }
            var locationFilter = this.location.Value;
            this.Response.Redirect(string.Format("~/search?q={0}&location={1}", filter, locationFilter));
        }
    }
}