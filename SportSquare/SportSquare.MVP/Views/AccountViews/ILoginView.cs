using SportSquare.MVP.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace SportSquare.MVP.Views.AccountViews
{
    public interface ILoginView: IView<LoginViewModel>
    {
            event EventHandler<LoginEventArgs> LoginDetails;
    }
}
