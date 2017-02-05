using SportSquare.MVP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace SportSquare.MVP.Presenters
{
    public class HomePresenter : Presenter<IHomeView>
    {
        public HomePresenter(IHomeView view) : base(view)
        {
        }
    }
}