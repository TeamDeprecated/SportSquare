using Ninject.Modules;
using SportSquare.MVP.Presenters;
using SportSquare.Services;
using SportSquare.Services.Account;
using SportSquare.Services.Contracts;

namespace SportSquare.MVP.App_Start.NinjectModules
{
    public class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IVenueService>().To<VenueService>();
            this.Bind<IipInfoGatherer>().To<IpInfoGatherer>();
            this.Bind<IUserService>().To<UserService>();

        }
    }
}