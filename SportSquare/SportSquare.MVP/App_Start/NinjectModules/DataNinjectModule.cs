using Ninject.Modules;
using SportSquare.Data;
using SportSquare.Data.Contracts;
using SportSquare.Data.Repositories;
using SportSquare.MVP.Presenters;
using SportSquare.Services;
using SportSquare.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportSquare.MVP.App_Start.NinjectModules
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(typeof(IGenericRepository<>)).To(typeof(GenericRepository<>));
            this.Bind<IVenueRepository>().To<VenueRepository>();
            this.Bind<ISportSquareDbContext>().To<SportSquareDbContext>();
        }
    }
}