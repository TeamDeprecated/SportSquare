using Ninject.Extensions.Conventions;
using Ninject.Modules;
using Ninject.Web.Common;

using SportSquare.Data;
using SportSquare.Data.AssemblyInfo;
using SportSquare.Data.Contracts;
using SportSquare.Data.UnitOfWork;

namespace SportSquare.MVP.App_Start.NinjectModules
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x => x.FromAssemblyContaining<IDataAssemblyInfo>()
                                    .SelectAllClasses()
                                    .BindDefaultInterfaces());

            this.Rebind<ISportSquareDbContext>().To<SportSquareDbContext>().InRequestScope();

            this.Rebind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
        }
    }
}