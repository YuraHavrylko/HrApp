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
            var persons = _unitOfWork.PersonRepository.GetAll(page: page, count: count);


            return View(persons);
        }
        
        public ActionResult FullInformation(int id)
        {
            var person = _unitOfWork.PersonRepository.Get(id);

            return View(person);
        }

        public ActionResult Find(string searchString)
        {
            searchString = "in";
            var personsSearchByJob = _unitOfWork.JobRepository.GetAllWhere(new Job() { JobName = searchString }).ToList();
            List<Person> persons = new List<Person>();
            for (int i = 0; i < personsSearchByJob.Count; i++)
            {
                persons.Add(_unitOfWork.PersonRepository.Get(personsSearchByJob[i].PersonId.Value));
            }
                foreach (var person in persons)
                {
                        person.Educations = _unitOfWork.EducationRepository.GetAllWhere(new Education() { PersonId = person.PersonId }).ToList();
                        person.WorkExperiences = _unitOfWork.WorkExpireanceRepository.GetAllWhere(new WorkExperience() { PersonId = person.PersonId }).ToList();
                        person.Jobs = _unitOfWork.JobRepository.GetAllWhere(new Job() { PersonId = person.PersonId }).ToList();
                        person.Interviews = _unitOfWork.InterviewRepository.GetAllWhere(new Interview() { PersonId = person.PersonId }).ToList();
                        person.ProfessionalSkills = _unitOfWork.ProfessionalSkillRepository.GetAllWhere(new ProfessionalSkill() { PersonId = person.PersonId }).ToList();
                        person.Languages = _unitOfWork.LanguageRepository.GetAllWhere(new Language() { PersonId = person.PersonId }).ToList();
                        person.PersonTypeJobs = _unitOfWork.TypeJobRepository.GetAllWhere(new TypeJob() { PersonId = person.PersonId }).ToList();

                    
                }
            
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
        public ActionResult Delete(int idPerson)
        {
            _unitOfWork.EducationRepository.Delete(idPerson);
            return RedirectToAction("Index", "Home", new { id = idPerson });
        }
    }
}