using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using HrApp.Infrastructure;
using HrApp.Models;
using HrApp.Models.Search;
using HrApp.Repositories;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace HrApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private UnitOfWork _unitOfWork;

        public HomeController(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
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
        [Authorize]
        public ActionResult Index(int page = 1, int count = 10)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var person = new PersonSearchModel();
                ViewBag.Count = count;
                ViewBag.Page = page;
                person.TypeLanguages = _unitOfWork.LanguagesNameRepository.GetAll().ToList();
                person.LanguageLevels = _unitOfWork.LanguageLevelRepository.GetAll().ToList();
                person.TypeJobsNames = _unitOfWork.TypeJobsNameRepository.GetAll().ToList();
                person.ApplicationUserId = this.User.Identity.GetUserId();

                ViewBag.CountPerson = _unitOfWork.PersonRepository.GetCount(User.Identity.GetUserId());
                ViewBag.PersonFind = person;
                var persons = _unitOfWork.PersonRepository.GetAllPersonsByHrId(person.ApplicationUserId, page, count);
               // var persons = _unitOfWork.PersonRepository.GetAll(page, count);
                return View("Index", new BigPersonModel() { PersonSearchModel = person, Persons = persons });
            }
            else
            {
                return this.RedirectToAction("Login");
            }
        }
        
        public ActionResult FullInformation(int id)
        {
            var person = _unitOfWork.PersonRepository.Get(id);

            return View(person);
        }

        //  
        // GET: /CRUD/Create  
        public ActionResult Create()
        {
            return View();
        }

        //  
        // POST: /CRUD/Create  
        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                person.ApplicationUserId = this.User.Identity.GetUserId();
                _unitOfWork.PersonRepository.Add(person);
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: Education/Edit/5
        public ActionResult Edit(int id)
        {
            var education = _unitOfWork.PersonRepository.Get(id);
            return View(education);
        }

        // POST: Education/Edit/5
        [HttpPost]
        public ActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PersonRepository.Edit(person);
                return RedirectToAction("FullInformation", "Home", new { id = person.PersonId });
            }

            return View(person);
        }

        // GET: Education/Delete/5
        public ActionResult Delete(int id)
        {
            _unitOfWork.PersonRepository.Delete(id);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Filter(BigPersonModel person = null, int page = 1, int count = 10)
        {

            if (person == null)
            {
                person = new BigPersonModel();
            }
            if (person.PersonSearchModel == null)
            {
                person.PersonSearchModel = new PersonSearchModel();
            }
            ViewBag.Count = count;
            ViewBag.Page = page;
            person.PersonSearchModel.TypeLanguages = _unitOfWork.LanguagesNameRepository.GetAll().ToList();
            person.PersonSearchModel.LanguageLevels = _unitOfWork.LanguageLevelRepository.GetAll().ToList();
            person.PersonSearchModel.TypeJobsNames = _unitOfWork.TypeJobsNameRepository.GetAll().ToList();

            ViewBag.CountPerson = _unitOfWork.PersonRepository.GetCountWhere(person.PersonSearchModel);

            var persons = _unitOfWork.PersonRepository.GetAllWhere(person.PersonSearchModel, page, count);
            person.Persons = persons;
            return View("Index", person);
        }
        
    }
}