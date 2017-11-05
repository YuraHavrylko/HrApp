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

namespace HrApp.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork _unitOfWork;

        public HomeController(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public ActionResult Index(int page = 1, int count = 10)
        {
            var person = new PersonSearchModel();
            ViewBag.Count = count;
            ViewBag.Page = page;
            person.TypeLanguages = _unitOfWork.LanguagesNameRepository.GetAll().ToList();
            person.LanguageLevels = _unitOfWork.LanguageLevelRepository.GetAll().ToList();
            person.TypeJobsNames = _unitOfWork.TypeJobsNameRepository.GetAll().ToList();

            ViewBag.CountPerson = _unitOfWork.PersonRepository.GetCount();
            ViewBag.PersonFind = person;
            var persons = _unitOfWork.PersonRepository.GetAll(page, count);

            return View("Index", new BigPersonModel() { PersonSearchModel = person, Persons = persons });
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