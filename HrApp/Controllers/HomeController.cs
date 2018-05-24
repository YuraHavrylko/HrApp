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
    using Rotativa;
    using System.Globalization;
    using System.Threading.Tasks;

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

        [ClaimsAccess(ClaimType = "access", Value = "hr:index")]
        public ActionResult Index(int page = 1, int count = 10)
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

        [ClaimsAccess(ClaimType = "access", Value = "hr:index")]
        public ActionResult FullInformation(int id)
        {
            var person = _unitOfWork.PersonRepository.Get(id);

            return View(person);
        }

        //  
        // GET: /CRUD/Create  
        [ClaimsAccess(ClaimType = "access", Value = "hr:index")]
        public ActionResult Create()
        {
            return View();
        }

        //  
        // POST: /CRUD/Create  
        [HttpPost]
        [ClaimsAccess(ClaimType = "access", Value = "hr:index")]
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
        [ClaimsAccess(ClaimType = "access", Value = "hr:index")]
        public ActionResult Edit(int id)
        {
            var education = _unitOfWork.PersonRepository.Get(id);
            return View(education);
        }

        // POST: Education/Edit/5
        [HttpPost]
        [ClaimsAccess(ClaimType = "access", Value = "hr:index")]
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
        [ClaimsAccess(ClaimType = "access", Value = "hr:index")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.PersonRepository.Delete(id);
            return RedirectToAction("Index", "Home");
        }

        [ClaimsAccess(ClaimType = "access", Value = "hr:index")]
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

        [ClaimsAccess(ClaimType = "access", Value = "hr:dashboard")]
        public ActionResult Dashboard()
        {
            ViewData["PersonCount"] = this._unitOfWork.PersonRepository.GetCountWhere(
                new PersonSearchModel() { ApplicationUserId = User.Identity.GetUserId() });
            var persons = this._unitOfWork.PersonRepository.GetAllPersonsByHrId(
                User.Identity.GetUserId());
            var interviewCount = 0;
            var personEducCount = 0;
            var personExpCount = 0;
            
            foreach (var person in persons)
            {
                interviewCount += this._unitOfWork.InterviewRepository.GetAllWhere(new Interview() { PersonId = person.PersonId.GetValueOrDefault()}).Count();
                if (this._unitOfWork.EducationRepository.GetAll().Count(education => education.PersonId == person.PersonId) > 0)
                {
                    personEducCount++;
                }
                if (this._unitOfWork.WorkExpireanceRepository.GetAll().Count(education => education.PersonId == person.PersonId) > 0)
                {
                    personExpCount++;
                }

            }

            ViewData["InterviewCount"] = interviewCount;
            ViewData["PersonEducCount"] = personEducCount; 
            ViewData["PersonExpCount"] = personExpCount; 
            return View(persons);
        }

        [HttpPost]
        [ClaimsAccess(ClaimType = "access", Value = "hr:dashboard")]
        public async Task<JsonResult> GroupPersonAge()
        {
            var persons = this._unitOfWork.PersonRepository.GetAllPersonsByHrId(
                User.Identity.GetUserId());
            var personAge = new Dictionary<string, int>();
            foreach (var person in persons)
            {
                try
                {
                    if (person.Birthday.HasValue)
                    {
                        var age = new DateTime((DateTime.Now - person.Birthday.Value).Ticks).Year;
                        if (personAge.ContainsKey(age.ToString()))
                        {
                            personAge[age.ToString()]++;
                        }
                        else
                        {
                            personAge.Add(age.ToString(), 1);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return Json(personAge);
        }

        [HttpPost]
        [ClaimsAccess(ClaimType = "access", Value = "hr:dashboard")]
        public async Task<JsonResult> GroupPersonExpireance()
        {
            var persons = this._unitOfWork.PersonRepository.GetAllPersonsByHrId(
                User.Identity.GetUserId());
            var personExp = new Dictionary<string, int>();
            foreach (var person in persons)
            {
                var exp = this._unitOfWork.WorkExpireanceRepository.GetAllWhere(
                    new WorkExperience() { PersonId = person.PersonId.GetValueOrDefault() });
                var expCount = 0;
                foreach (var experience in exp)
                {
                    expCount =+ new DateTime((experience.FinishDate.Value - experience.StartDate.Value).Ticks).Month;
                }
                
                if (personExp.ContainsKey(expCount.ToString()))
                {
                    personExp[expCount.ToString()]++;
                }
                else
                {
                    personExp.Add(expCount.ToString(), 1);
                }
            }

            return Json(personExp);
        }

        [ClaimsAccess(ClaimType = "access", Value = "hr:dashboard")]
        public async Task<JsonResult> GroupPersonJob()
        {
            var persons = this._unitOfWork.PersonRepository.GetAllPersonsByHrId(
                User.Identity.GetUserId());
            var personAge = new Dictionary<string, int>();
            foreach (var person in persons)
            {
                try
                {
                    var jobTypesPerson = this._unitOfWork.TypeJobRepository.GetAll().Where(job => job.PersonId == person.PersonId);
                    foreach (var  job in jobTypesPerson)
                    {
                        if (personAge.ContainsKey(job.TypeJobName))
                        {
                            personAge[job.TypeJobName]++;
                        }
                        else
                        {
                            personAge.Add(job.TypeJobName, 1);
                        }
                    }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return Json(personAge);
        }

        [HttpPost]
        [ClaimsAccess(ClaimType = "access", Value = "hr:dashboard")]
        public async Task<JsonResult> GroupUser()
        {
            var users = new Dictionary<string, int>();
            for (int i = 30; i > 0; i--)
            {
                users.Add(DateTime.Now.AddDays((double)-i).ToString("d"), 0);
            }

            var persons = this._unitOfWork.PersonRepository.GetAllPersonsByHrId(
                User.Identity.GetUserId());
            foreach (var person in persons)
            {
                try
                {
                    var interview = this._unitOfWork.InterviewRepository.GetAll().Where(job => job.PersonId == person.PersonId);
                    foreach (var job in interview)
                    {
                        users[job.InterviewDate.ToString("d")]++;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return Json(users);
        }

        [HttpPost]
        [ClaimsAccess(ClaimType = "access", Value = "hr:dashboard")]
        public async Task<JsonResult> Calendar()
        {
            var events = new List<Tuple<string, DateTime>>();
            var persons = this._unitOfWork.PersonRepository.GetAllPersonsByHrId(
                User.Identity.GetUserId());
            foreach (var person in persons)
            {
                try
                {
                    var interview = this._unitOfWork.InterviewRepository.GetAll().Where(job => job.PersonId == person.PersonId);
                    foreach (var job in interview)
                    {
                        events.Add(new Tuple<string, DateTime>("Interview with " + person.FirstName + " " + person.LastName, job.InterviewDate));
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return Json(events);
        }

        [HttpPost]
        public ActionResult ShowCVInformation(int personId)
        {
            if (personId == 0)
            {
                return RedirectToAction("Index");
            }
            var person = _unitOfWork.PersonRepository.Get(personId);
            var report = new PartialViewAsPdf("_CVPartial", person);
            byte[] applicationPDFData = report.BuildPdf(ControllerContext);

            
            var file  = this._unitOfWork.PersonRepository.ConvertCVToPdf(personId, applicationPDFData);

            if (!System.IO.File.Exists(file))
            {
               return HttpNotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(file);
            var response = new FileContentResult(fileBytes, "application/octet-stream")
            {
                FileDownloadName = "CV.pdf"
            };
            return response;
        }
   }
}