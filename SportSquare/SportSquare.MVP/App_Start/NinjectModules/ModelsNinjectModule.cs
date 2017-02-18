using System;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using Ninject.Web.Common;
using SportSquare.Models.AssemblyInfo;

namespace SportSquare.MVP.App_Start.NinjectModules
{
    public class ModelsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind(x => x.FromAssemblyContaining<IModelAssemblyInfo>()
                                    .SelectAllInterfaces()
                                    .EndingWith("Factory")
                                    .BindToFactory()
                                    .Configure(c => c.InSingletonScope()));
        }
    }
}