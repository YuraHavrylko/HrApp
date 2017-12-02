using Microsoft.Owin;

[assembly: OwinStartup(typeof(HrApp.Startup))]
namespace HrApp
{
    using HrApp.Infrastructure;

    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security.Cookies;

    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<ApplicationContext>(ApplicationContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions
                    {
                        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                        LoginPath = new PathString("/Account/Login"),
                    });
        }
    }
}