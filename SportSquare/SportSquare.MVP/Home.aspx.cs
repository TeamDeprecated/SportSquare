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
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}