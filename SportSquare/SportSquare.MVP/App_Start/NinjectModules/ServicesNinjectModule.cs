using Ninject.Modules;
using SportSquare.MVP.Presenters;
using SportSquare.Services;
using SportSquare.Services.Contracts;
using Ninject.Extensions.Conventions;
using SportSquare.Services.AssemblyInfo;

namespace SportSquare.MVP.App_Start.NinjectModules
{
    public class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<SearchPresenter>().ToSelf();
            this.Bind<IVenueService>().To<VenueService>();
            this.Bind<ICommentService>().To<CommentService>();
            this.Bind<IipInfoGatherer>().To<IpInfoGatherer>();

            //this.Kernel.Bind(x => x.FromAssemblyContaining<IServiceAssemblyInfo>()
            //                    .SelectAllClasses()
            //                    .InheritedFrom<IService>()
            //                    .BindDefaultInterface()
            //                    .Configure(y => y.InRequestScope())
            //);
        }
    }
}