using Ninject.Modules;
using SportSquare.MVP.Presenters;
using SportSquare.Services;
using SportSquare.Services.Contracts;

namespace SportSquare.MVP.App_Start.NinjectModules
{
    public class SearchNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<SearchPresenter>().ToSelf();
            this.Bind<ISearchService>().To<SearchService>();
        }
    }
}