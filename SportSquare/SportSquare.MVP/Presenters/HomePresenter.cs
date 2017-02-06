using SportSquare.MVP.Models;
using SportSquare.MVP.Views;
using SportSquare.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace SportSquare.MVP.Presenters
{
    public class HomePresenter : Presenter<IHomeView>
    {
        private readonly IpInfoGatherer gatherer;

        public HomePresenter(IHomeView view, IpInfoGatherer gatherer) : base(view)
        {
            this.gatherer = gatherer;
            this.View.IpDetails += this.IpDetails;
        }

        private void IpDetails(object sender, HomeEventArgs e)
        {
            //TODO comment hardcoded Ip address and use the one comming from the event!\
            //var city = gatherer.GetUserCityByIp(e.Ip);
            // hard coded for test purposes!!
            var city = gatherer.GetUserCityByIp("87.126.72.111");

            this.View.Model.City = city;
        }
    }
}