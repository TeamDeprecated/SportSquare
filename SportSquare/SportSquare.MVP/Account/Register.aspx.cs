using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using SportSquare.MVP.Models;
using SportSquare.MVP.Presenters.Account;
using WebFormsMvp;
using WebFormsMvp.Web;
using SportSquare.MVP.Models.AccountModels.Register;
using SportSquare.MVP.Views.AccountViews;
using SportSquare.Auth;
using SportSquare.Enums;

namespace SportSquare.MVP.Account
{
    [PresenterBinding(typeof(RegisterPresenter))]
    public partial class Register : MvpPage<RegisterViewModel>, IRegisterView
    {
        public event EventHandler<RegisterEventArgs> RegisterDetails;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GenderTypeView.DataSource = Enum.GetValues(typeof(GenderType));
            this.GenderTypeView.DataBind();
        }
        protected void CreateUser_Click(object sender, EventArgs e)
        {
           
            this.RegisterDetails?.Invoke(sender, new RegisterEventArgs(this.Context,Email.Text, Password.Text,FirstName.Text,LastName.Text,GenderTypeView.Text, Age.Text));
            if (this.Model.Succeeded)
            {
             
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = this.Model.ErrorMessage;
            }
        }
    }
}