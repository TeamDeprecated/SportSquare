using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SportSquare.MVP.Models;
using SportSquare.MVP.Models.AccountModels.Register;
using SportSquare.MVP.Views.AccountViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace SportSquare.MVP.Presenters.Account
{
    public class RegisterPresenter : Presenter<IRegisterView>
    {
        public RegisterPresenter(IRegisterView view) : base(view)
        {
            this.View.RegisterDetails += View_RegisterDetails;
        }

        private void View_RegisterDetails(object sender, RegisterEventArgs e)
        {

            //TODO abstract this into service!
            var manager = e.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = e.Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = e.Email, Email = e.Email };
            IdentityResult result = manager.Create(user, e.PasswordHash);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                this.View.Model.Succeeded = true;
            }
            else
            {
                this.View.Model.ErrorMessage = result.Errors.FirstOrDefault();

            }
        }
    }
}