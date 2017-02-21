using Ninject.Modules;
using Ninject.Web.Common;
using SportSquare.Services;
using SportSquare.Services.Contracts;

namespace SportSquare.MVP.App_Start.NinjectModules
{
    public class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IVenueService>().To<VenueService>().InRequestScope();
            this.Bind<ICommentService>().To<CommentService>().InRequestScope();
            this.Bind<IipInfoGatherer>().To<IpInfoGatherer>().InRequestScope();
            this.Bind<IUserService>().To<UserService>().InRequestScope();
            this.Bind<IRatingService>().To<RatingService>().InRequestScope();
            this.Bind<IWishListService>().To<WishListService>().InRequestScope();


            //this.Kernel.Bind(x => x.FromAssemblyContaining<IServiceAssemblyInfo>()
                                //.SelectAllClasses()
                                //.InheritedFrom<IService>()
                                //.BindDefaultInterface()
                                //.Configure(y => y.InRequestScope())
            //);
        }
    }
}