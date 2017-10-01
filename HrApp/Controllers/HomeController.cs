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