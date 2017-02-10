using SportSquare.MVP.Models.AccountModels.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace SportSquare.MVP.Views.AccountViews
{
    public interface IRegisterView:IView<RegisterViewModel>
    {
        event EventHandler<RegisterEventArgs> RegisterDetails;

    }
}
