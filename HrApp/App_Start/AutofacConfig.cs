using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrApp.App_Start
{
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Mvc;

    using HrApp.Contract.Repositories;
    using HrApp.Infrastructure;

    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<UnitOfWork>().WithParameter("connection", "HRDataBase");

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}