using AjaxControlToolkit;
using SportSquare.MVP.Models.VenueDetails;
using SportSquare.MVP.Presenters;
using SportSquare.MVP.Views;
using SportSquareDTOs;
using System;
using System.Web.ModelBinding;
using System.Web.UI.WebControls;
using WebFormsMvp;
using Microsoft.AspNet.Identity;
using WebFormsMvp.Web;

namespace SportSquare.MVP
{
    [PresenterBinding(typeof(VenueDetailsPresenter))]

    public partial class VenueDetails : MvpPage<VenueDetailsViewModel>, IVenueDetailsView
    {
        public event EventHandler<GetVenueDetailsEventArgs> OnFormGetItems;
        public event EventHandler<UpdateRatingEventArgs> UpdateRating;
        public event EventHandler<AddCommentEventArgs> AddComment;

        public VenueDetails()
        {
            this.AutoDataBind = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        public VenueDetailedDTO FormViewVenueDetails_GetItem([QueryString] int? id)
        {
            this.OnFormGetItems?.Invoke(this, new GetVenueDetailsEventArgs(id));
            return this.Model.Venue;
        }

        public void VenueRating_Changed(object sender, RatingEventArgs e)
        {
            this.UpdateRating?.Invoke(sender, new UpdateRatingEventArgs(this.User.Identity.GetUserId(), this.Request.QueryString.GetValues("id")[0], e.Value));
        }

        protected void Save_Click(object sender, EventArgs e)
        {

        }

        protected void SaveComment_Click(object sender, EventArgs e)
        {
            var comment = ((TextBox)this.FormViewVenueDetails.FindControl("VenueComment")).Text;
            this.AddComment?.Invoke(sender, new AddCommentEventArgs(this.User.Identity.GetUserId(), this.Request.QueryString.GetValues("id")[0], comment));

            this.FormViewVenueDetails.DataBind();
            //this.UpdatePanel.Update();
        }



    }
}