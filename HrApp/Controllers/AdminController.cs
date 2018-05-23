using HrApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Unity.Interception.Utilities;

namespace HrApp.Controllers
{
    using System.Globalization;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AutoMapper;

    using HrApp.Contract.Repositories;
    using HrApp.Models;
    using HrApp.Repositories;
    using HrApp.ViewModels.Admin;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Newtonsoft.Json;

    public class AdminController : Controller
    {
        private UnitOfWork _unitOfWork;

        private GenericRepository<RoleClaim> _roleClaimRepository;
        private GenericRepository<Person> _personRepository;

        public AdminController(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._roleClaimRepository = new GenericRepository<RoleClaim>(new ApplicationDbContext());
            this._personRepository = new GenericRepository<Person>(new ApplicationDbContext());
        }

        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private ApplicationRoleManager RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
        }

        [ClaimsAccess(ClaimType = "access", Value = "admin:index")]
        public ActionResult Index()
        {
            var usersWithRoles = UserManager.Users.AsEnumerable();
            ViewData["UserCount"] = UserManager.Users.ToList().Count();
            ViewData["RolesCount"] = RoleManager.Roles.ToList().Count();
            ViewData["Language"] = _unitOfWork.LanguagesNameRepository.GetAll().Count();
            ViewData["Skills"] = _unitOfWork.ProfessionalSkillRepository.GetAll().Count();

            ViewData["ConfirmedEmailCount"] = UserManager.Users.Count(user => user.EmailConfirmed);
            ViewData["Locked"] = UserManager.Users.Count(user => user.LockoutEndDateUtc.HasValue);

            return View(usersWithRoles);
        }

        [ClaimsAccess(ClaimType = "access", Value = "admin:index")]
        [HttpPost]
        public async Task<JsonResult> GroupUserRole()
        {
            var userRole = new Dictionary<string, int>();
            foreach (var role in RoleManager.Roles.ToList())
            {
                
                int users = 0;
                try
                {
                    var c = UserManager.Users.ToList();
                    users = c.Where(
                        user => user.Roles.FirstOrDefault(identityUserRole => identityUserRole.RoleId == role.Id)
                                != null).Count();
                }
                catch (Exception e)
                {
                    
                }
                
                userRole.Add(role.Name, users);
            }

            return Json(userRole);
        }

        [ClaimsAccess(ClaimType = "access", Value = "admin:index")]
        [HttpPost]
        public async Task<JsonResult> GroupUserRoleLogin()
        {
            var userRole = new Dictionary<string, Dictionary<string, int>>();
            foreach (var role in RoleManager.Roles.ToList())
            {

                var c = UserManager.Users.ToList();
                var users = c.Where(
                    user => user.Roles.FirstOrDefault(identityUserRole => identityUserRole.RoleId == role.Id) != null);


                var lastSixMonths = Enumerable.Range(0, 6).Select(i => DateTime.Now.AddMonths(i - 6))
                    .Select(date => date.Month);
                var time = new Dictionary<string, int>();
                foreach (var month in lastSixMonths)
                {
                    time.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month), users.Count(user => user.LastLoginDate?.Month == month));
                }
                userRole.Add(role.Name, time);
            }

            return Json(userRole);
        }

        [ClaimsAccess(ClaimType = "access", Value = "admin:index")]
        [HttpPost]
        public async Task<JsonResult> GroupUser()
        {
            var users = new Dictionary<string, int>();
            var lastSixMonths = Enumerable.Range(0, 6).Select(i => DateTime.Now.AddMonths(i - 6))
                .Select(date => date.Month);
            foreach (var month in lastSixMonths)
            {
                users.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month), UserManager.Users.ToList().Count(user => user.RegistrationDate?.Month == month));
            }

            return Json(users);
        }

        [ClaimsAccess(ClaimType = "access", Value = "admin:roles")]
        public ActionResult Roles()
        {
            var roles = RoleManager.Roles.AsEnumerable();

            return View(roles);
        }

        [ClaimsAccess(ClaimType = "access", Value = "admin:roles")]
        [HttpGet]
        public async Task<PartialViewResult> CreateRole()
        {
            var role = new RoleViewModel();
            return PartialView(role);
        }

        [ClaimsAccess(ClaimType = "access", Value = "admin:roles")]
        [HttpPost]
        public async Task<ActionResult> CreateRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                await RoleManager.CreateAsync(new IdentityRole(model.Name));
                return RedirectToAction("Roles");
            }

            return View(model);
        }

        [ClaimsAccess(ClaimType = "access", Value = "admin:roles")]
        public async Task<PartialViewResult> EditRole(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);

            return PartialView(Mapper.Map<IdentityRole, RoleViewModel>(role));
        }

        [ClaimsAccess(ClaimType = "access", Value = "admin:roles")]
        [HttpPost]
        public async Task<ActionResult> EditRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await RoleManager.FindByIdAsync(model.Id);
                role.Name = model.Name;
                await RoleManager.UpdateAsync(role);

                return RedirectToAction("Roles");
            }

            return View(model);
        }

        [ClaimsAccess(ClaimType = "access", Value = "admin:roles")]
        [HttpGet]
        public async Task<PartialViewResult> EditClaim(string id)
        {
            var roleClaim = this._roleClaimRepository.Get(claim => claim.RoleId == id);
            IEnumerable<string> allClaims = new List<string>()
                                         {
                                             "admin:index",
                                             "admin:user-roles",
                                             "admin:users",
                                             "admin:roles",
                                             "language:level",
                                             "language:name",
                                             "typejob:name",
                                             "hr:index",
                                             "hr:dashboard",
                                         };
            return PartialView(new Tuple<IEnumerable<string>, IEnumerable<RoleClaim>, string>(allClaims, roleClaim, id));
        }

        [ClaimsAccess(ClaimType = "access", Value = "admin:roles")]
        [HttpPost]
        public async Task<ActionResult> EditClaim(FormCollection collection)
        {
            var roles = this._roleClaimRepository.Get(claim => claim.RoleId == collection["Id"]);
            foreach (var identityUserRole in roles.ToList())
            {
                this._roleClaimRepository.Delete(identityUserRole.Id);
            }
            foreach (var item in collection)
            {
                if (item == "Id")
                {
                    continue;
                }
                this._roleClaimRepository.Add(new RoleClaim() { ClaimType = "access", ClaimValue = item.ToString(), RoleId = collection["Id"] });
            }
          
            return RedirectToAction("Roles");
        }

        [ClaimsAccess(ClaimType = "access", Value = "admin:roles")]
        [HttpGet]
        public async Task<RedirectToRouteResult> DeleteRole(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            await RoleManager.DeleteAsync(role);
            return RedirectToAction("Roles");
        }

        [ClaimsAccess(ClaimType = "access", Value = "admin:user-roles")]
        public async Task<ActionResult> UserRoles()
        {
            var userRoles = Mapper.Map<List<UserRoleViewModel>>(UserManager.Users.ToList());
            foreach (var userRoleViewModel in userRoles)
            {
                var user = await UserManager.FindByIdAsync(userRoleViewModel.Id);
                userRoleViewModel.AllRoles = Mapper.Map<List<RoleViewModel>>(RoleManager.Roles.ToList());
                userRoleViewModel.Roles = Mapper.Map<List<RoleViewModel>>(user.Roles.ToList());
            }

            return View(userRoles);
        }

        [ClaimsAccess(ClaimType = "access", Value = "admin:user-roles")]
        public async Task<PartialViewResult> EditUserRole(string id)
        {
            var userRoles = Mapper.Map<UserRoleViewModel>(await UserManager.FindByIdAsync(id));
            userRoles.Roles = Mapper.Map<List<RoleViewModel>>((await UserManager.FindByIdAsync(id)).Roles.ToList());
            userRoles.AllRoles = Mapper.Map<List<RoleViewModel>>(RoleManager.Roles.ToList());
           
            return PartialView(userRoles);
        }

        [ClaimsAccess(ClaimType = "access", Value = "admin:user-roles")]
        [HttpPost]
        public async Task<ActionResult> EditUserRole(FormCollection collection)
        {
            var user = await UserManager.FindByIdAsync(collection["Id"]);
            foreach (var identityUserRole in user.Roles.ToList())
            {
                await UserManager.RemoveFromRoleAsync(user.Id, RoleManager.FindById(identityUserRole.RoleId).Name);
            }
            for (int i = 0; i < collection.Count - 1; i++)
            {
                var role = await RoleManager.FindByIdAsync(collection.GetKey(i));
                await UserManager.AddToRoleAsync(user.Id, role.Name);
            }
            
            return RedirectToAction("UserRoles");
        }

        [ClaimsAccess(ClaimType = "access", Value = "admin:users")]
        public ActionResult Users()
        {
            var roles = UserManager.Users.AsEnumerable();

            return View(roles);
        }

        [ClaimsAccess(ClaimType = "access", Value = "admin:users")]
        public async Task<PartialViewResult> EditUser(string id)
        {
            var user = Mapper.Map<UserViewModel>(await UserManager.FindByIdAsync(id));
            user.PersonList = this._unitOfWork.PersonRepository.GetAll(1, int.MaxValue).ToList();
            return PartialView(user);
        }

        [ClaimsAccess(ClaimType = "access", Value = "admin:users")]
        [HttpPost]
        public async Task<ActionResult> EditUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByIdAsync(model.Id);
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.EmailConfirmed = model.EmailConfirmed;
                user.PhoneNumberConfirmed = model.PhoneNumberConfirmed;
                user.LockoutEnabled = model.LockoutEnabled;
                user.TwoFactorEnabled = model.TwoFactorEnabled;

                await UserManager.UpdateAsync(user);

                return RedirectToAction("Users");
            }

            return View(model);
        }

        [ClaimsAccess(ClaimType = "access", Value = "admin:users")]
        [HttpGet]
        public async Task<RedirectToRouteResult> DeleteUser(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            await UserManager.DeleteAsync(user);
            return RedirectToAction("Users");
        }
    }
}
