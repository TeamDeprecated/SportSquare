using SportSquare.MVP.Views.AdminPanel;
using System;
using SportSquare.MVP.Models.Search;

using WebFormsMvp.Web;
using WebFormsMvp;
using SportSquare.MVP.Presenters.AdminPanel;
using System.Text;
using System.Collections.Generic;
using SportSquareDTOs;

namespace SportSquare.MVP.AdminPanel
{
    [PresenterBinding(typeof(EditVenuesPresenter))]
    public partial class EditVenues : MvpPage<SearchViewModel>, IEditVenuesView
    {
        public event EventHandler<SearchEventArgs> QueryEvent;

        protected void Page_Load(object sender, EventArgs e)
        {
            string filter = string.Empty;
            string locationFilter = string.Empty;
            if (this.Request.QueryString.Count < 1)
            {
                this.QueryEvent?.Invoke(sender, new SearchEventArgs(filter, locationFilter));
                return;
            }
            filter = this.Request.QueryString.GetValues("q")[0];
            locationFilter = this.Request.QueryString.GetValues("location")[0];
            this.QueryEvent?.Invoke(sender, new SearchEventArgs(filter, locationFilter));
            this.VenueList.DataSource = Model.FilteredVenues;
            this.VenueList.DataBind();
        }

        public void Search_Click(object sender, EventArgs e)
        {
            this.Response.Redirect(string.Format("~/adminpanel/editvenues?q={0}&location={1}", filter.Value, location.Value));

        }

        public void Edit_Click(object sender, EventArgs e)
        {
            
            this.Response.Redirect(string.Format("~/adminpanel/editvenues?q={0}&location={1}", filter.Value, location.Value));
        }

        public void Delete_Click(object sender, EventArgs e)
        {
            this.Response.Redirect(string.Format("~/adminpanel/editvenues?q={0}&location={1}", filter.Value, location.Value));
        }

        public string NormalizeString(string text)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(text[0]);

            for(int i = 1; i < text.Length; i++)
            {
                builder.Append(text[i].ToString().ToLower());
            }

            return builder.ToString();
        }
    }
}