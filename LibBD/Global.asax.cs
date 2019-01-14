using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using LibDB.DAL;
using Ninject;
using Ninject.Web.Common.WebHost;

namespace LibBD
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected override IKernel CreateKernel()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IRepository<Author>>().To<AuthorRepository>();
            kernel.Bind<IRepository<Organization>>().To<OrganizationRepository>();
            return kernel;
        }
    }
}
