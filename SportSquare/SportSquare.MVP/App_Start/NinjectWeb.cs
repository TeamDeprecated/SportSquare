[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SportSquare.MVP.App_Start.NinjectWeb), "Start")]

namespace SportSquare.MVP.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject.Web;

    public static class NinjectWeb 
    {
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
        }
    }
}
