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

        public ActionResult Index()
        {
            var persons = _unitOfWork.PersonRepository.GetAll();
            //int i = 0;
            foreach (var person in persons)
            {
                person.Educations = _unitOfWork.EducationRepository.GetAllWhere(new Education() {PersonId = person.PersonId}).ToList();
                person.WorkExperiences = _unitOfWork.WorkExpireanceRepository.GetAllWhere(new WorkExperience() { PersonId = person.PersonId }).ToList();
                person.Jobs = _unitOfWork.JobRepository.GetAllWhere(new Job() { PersonId = person.PersonId }).ToList();
                person.Interviews = _unitOfWork.InterviewRepository.GetAllWhere(new Interview() { PersonId = person.PersonId }).ToList();
                person.ProfessionalSkills = _unitOfWork.ProfessionalSkillRepository.GetAllWhere(new ProfessionalSkill() { PersonId = person.PersonId }).ToList();
                person.Languages = _unitOfWork.LanguageRepository.GetAllWhere(new Language() { PersonId = person.PersonId }).ToList();
                person.PersonTypeJobs = _unitOfWork.TypeJobRepository.GetAllWhere(new TypeJob() { PersonId = person.PersonId }).ToList();
                //if (i > 10)
                //    break;
                //i++;
            }
            return View(persons);
        }
        
        public ActionResult FullInformation()
        {
            return View();
        }
    }
}