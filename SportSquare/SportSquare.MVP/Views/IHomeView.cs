using SportSquare.MVP.Models;
using System;
using WebFormsMvp;

namespace SportSquare.MVP.Views
{
    public interface IHomeView :IView<HomeViewModel>
    {
        event EventHandler<HomeEventArgs> IpDetails;

    }
}