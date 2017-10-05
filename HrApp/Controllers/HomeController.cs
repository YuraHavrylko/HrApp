using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrApp.Infrastructure;
using HrApp.Models;
using HrApp.Repositories;

namespace HrApp.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork _unitOfWork;

        public HomeController()
        {
            _unitOfWork = new UnitOfWork("HRDataBase");
        }

        public ActionResult Index(int page = 1, int count = 10)
        {
            ViewBag.CountPerson = _unitOfWork.PersonRepository.GetCount();
            ViewBag.Count = count;
            ViewBag.Page = page;
            ViewBag.Languages = _unitOfWork.LanguagesNameRepository.GetAll();
            ViewBag.LanguageLevel = _unitOfWork.LanguageLevelRepository.GetAll();
            ViewBag.TypeJob = _unitOfWork.TypeJobsNameRepository.GetAll();

            var persons = _unitOfWork.PersonRepository.GetAll(page: page, count: count);


            return View(persons);
        }
        
        public ActionResult FullInformation(int id)
        {
            var person = _unitOfWork.PersonRepository.Get(id);

            return View(person);
        }

        public ActionResult Find(string searchString, int page = 1, int count = 10)
        {
            ViewBag.CountPerson = _unitOfWork.PersonRepository.GetCountWhere(job : new Job() { JobName = searchString });
            ViewBag.Count = count;
            ViewBag.Page = page;
            ViewBag.Languages = _unitOfWork.LanguagesNameRepository.GetAll();
            ViewBag.LanguageLevel = _unitOfWork.LanguageLevelRepository.GetAll();
            ViewBag.TypeJob = _unitOfWork.TypeJobsNameRepository.GetAll();

            var persons = _unitOfWork.PersonRepository.GetAllWhere(job: new Job() { JobName = searchString }, page: page, count: count);

            return View("Index",persons);
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

        public ActionResult Filter(int? SalaryStart = null, int? SalaryFinish = null, 
            string LanguageName = null, string LanguageLevelName = null, string TypeJobName = null,
            int page = 1, int count = 10)
        {
            ViewBag.CountPerson = _unitOfWork.PersonRepository.GetCountWhere(
                person: new Person() { SalaryStart = SalaryStart, SalaryFinish = SalaryFinish}, 
                language : new Language(){ LanguageName = LanguageName, LanguageLevelName = LanguageLevelName });

            ViewBag.Count = count;
            ViewBag.Page = page;
            ViewBag.Languages = _unitOfWork.LanguagesNameRepository.GetAll();
            ViewBag.LanguageLevel = _unitOfWork.LanguageLevelRepository.GetAll();
            ViewBag.TypeJob = _unitOfWork.TypeJobsNameRepository.GetAll();

            var persons = _unitOfWork.PersonRepository.GetAllWhere(
                person: new Person() { SalaryStart = SalaryStart, SalaryFinish = SalaryFinish }, 
                language: new Language() { LanguageName = LanguageName, LanguageLevelName = LanguageLevelName }, 
                typeJob: new TypeJob(){TypeJobName = TypeJobName}, 
                page: page, count: count);

            return View("Index", persons);
        }
    }
}