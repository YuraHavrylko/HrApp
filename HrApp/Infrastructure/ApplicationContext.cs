namespace HrApp.Infrastructure
{
    using HrApp.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext()
            : base("HRDataBase", throwIfV1Schema: false) { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}