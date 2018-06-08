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
    using HrApp.Models;
    using HrApp.Repositories;

    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<UnitOfWork>().WithParameter("connection", "HRDataBase");
            builder.RegisterType<GenericRepository<RoleClaim>>().WithParameter("connection", "HRDataBase");

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}