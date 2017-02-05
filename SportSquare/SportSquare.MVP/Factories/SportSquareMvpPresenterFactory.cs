using System;
using WebFormsMvp;
using WebFormsMvp.Binder;

namespace SportSqure.MVP.Factories
{
    public class SportSquareMvpPresenterFactory : IPresenterFactory
    {
        private readonly ICustomPresenterFactory factory;

        public SportSquareMvpPresenterFactory(ICustomPresenterFactory factory)
        {
            this.factory = factory;
        }

        public IPresenter Create(Type presenterType, Type viewType, IView viewInstance)
        {
            return this.factory.GetPresenter(presenterType, viewInstance);
        }

        public void Release(IPresenter presenter)
        {
            var disposable = presenter as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}