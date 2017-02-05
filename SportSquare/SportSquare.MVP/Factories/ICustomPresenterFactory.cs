using System;
using WebFormsMvp;

namespace SportSqure.MVP.Factories
{
    public  interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance);
    }
}