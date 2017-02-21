using SportSquare.MVP.Models.AdminPanel;
using SportSquare.MVP.Models.Search;
using SportSquare.MVP.Models.VenueDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace SportSquare.MVP.Views.AdminPanel
{
    public interface IEditVenuesView : IView<EditVenuesViewModel>
    {
        event EventHandler<SearchEventArgs> QueryEvent;

        event EventHandler<StringEventArgs> VenueDetailsId;

        event EventHandler<UpdateVenueEventArgs> UpdateVenueDetails;
    }
}
    