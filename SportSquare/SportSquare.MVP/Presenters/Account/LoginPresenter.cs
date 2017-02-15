using SportSquare.MVP.Views.AccountViews;
using System.Web;
using WebFormsMvp;
using SportSquare.MVP.Models.AccountModels;
using Microsoft.AspNet.Identity.Owin;
using SportSquare.Auth;

namespace SportSquare.MVP.Presenters.Account
{
    public class LoginPresenter : Presenter<ILoginView>
    {
        public LoginPresenter(ILoginView view) : base(view)
        {
       
            this.View.LoginDetails += LoginDetails;
        }

        private void LoginDetails(object sender, LoginEventArgs e)
        {
            //TODO check if this logic has to be extracted to Service!
            var manager = e.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signinManager = e.Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

            var result = signinManager.PasswordSignIn(e.Email, e.PasswordHash, e.RememberMeChecked, shouldLockout: true);
            this.View.Model.result = result;
        }
    }
}