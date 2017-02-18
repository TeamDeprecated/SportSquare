using Ninject.Modules;
using SportSquare.MVP.Presenters;
using SportSquare.Services;
using SportSquare.Services.Account;
using SportSquare.Services.Contracts;
using Ninject.Extensions.Conventions;
using SportSquare.Services.AssemblyInfo;

namespace SportSquare.MVP.App_Start.NinjectModules
{
    public class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IVenueService>().To<VenueService>();
            this.Bind<ICommentService>().To<CommentService>();
            this.Bind<IipInfoGatherer>().To<IpInfoGatherer>();
            this.Bind<IUserService>().To<UserService>();

            //this.Kernel.Bind(x => x.FromAssemblyContaining<IServiceAssemblyInfo>()
            //                    .SelectAllClasses()
            //                    .InheritedFrom<IService>()
            //                    .BindDefaultInterface()
            //                    .Configure(y => y.InRequestScope())
            //);
        }
    }
}