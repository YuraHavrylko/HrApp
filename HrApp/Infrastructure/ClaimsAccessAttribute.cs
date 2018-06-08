namespace HrApp.Infrastructure
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.WebSockets;

    using Microsoft.AspNet.Identity.Owin;
    using HrApp.Contract.Repositories;
    using HrApp.Models;
    using HrApp.Repositories;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ClaimsAccessAttribute : AuthorizeAttribute
    {
        public string ClaimType { get; set; }
        public string Value { get; set; }

        private GenericRepository<AspNetRoles> repository;
        private GenericRepository<RoleClaim> repositoryClaim;

        public ClaimsAccessAttribute()
        {
            this.repository = new GenericRepository<AspNetRoles>(new ApplicationDbContext());
            this.repositoryClaim = new GenericRepository<RoleClaim>(new ApplicationDbContext());
        }

        protected override bool AuthorizeCore(HttpContextBase context)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                return false;
            }
            var roles = repository.GetAll();
            var userRoles = new List<AspNetRoles>();
            foreach (var role in roles)
            {
                if (context.User.IsInRole(role.Name))
                {
                    userRoles.Add(role);
                }
            }

            var claims = repositoryClaim.Get(claim => userRoles.Any(role => role.Id == claim.RoleId));
            if (!claims.Any(claim => claim.ClaimValue == Value && claim.ClaimType == ClaimType))
            {
                throw new HttpException(403, "Forbidden");
            }
            return true;
        }
    }
}