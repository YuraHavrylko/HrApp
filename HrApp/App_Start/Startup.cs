using Microsoft.Owin;

[assembly: OwinStartup(typeof(HrApp.Startup))]
namespace HrApp
{
    using AutoMapper;

    using HrApp.Infrastructure;
    using HrApp.Models;
    using HrApp.ViewModels.Admin;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin.Security.Cookies;

    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<ApplicationContext>(ApplicationContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

            app.UseCookieAuthentication(
                new CookieAuthenticationOptions
                    {
                        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                        LoginPath = new PathString("/Account/Login"),
                    });

            Mapper.Initialize(cfg => {
                    cfg.CreateMap<IdentityRole, RoleViewModel>();
                    cfg.CreateMap<RoleViewModel, IdentityRole>();

                    cfg.CreateMap<IdentityUserRole, RoleViewModel>().ForMember(model => model.Id, expression => expression.MapFrom(role => role.RoleId));
                    cfg.CreateMap<RoleViewModel, IdentityUserRole>().ForMember(model => model.RoleId, expression => expression.MapFrom(role => role.Id));

                    cfg.CreateMap<UserRoleViewModel, ApplicationUser>();
                    cfg.CreateMap<ApplicationUser, UserRoleViewModel>();

                    cfg.CreateMap<UserViewModel, ApplicationUser>();
                    cfg.CreateMap<ApplicationUser, UserViewModel>();
            });
        }
    }
}