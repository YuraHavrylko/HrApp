using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrApp.Infrastructure;
using HrApp.Models;

namespace HrApp.Controllers
{
    public class WorkExpireanceController : Controller
    {
        private UnitOfWork _unitOfWork;

        public WorkExpireanceController()
        {
            _unitOfWork = new UnitOfWork("HRDataBase");
        }

        // GET: WorkExpireance
        public ActionResult Index()
        {
            return View();
        }

        // GET: WorkExpireance/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WorkExperience/Create
        public ActionResult Create(int id)
        {
            var education = new WorkExperience();
            education.PersonId = id;
            return View(education);
        }

        // POST: WorkExperience/Create
        [HttpPost]
        public ActionResult Create(WorkExperience experience)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.WorkExpireanceRepository.Add(experience);
                return RedirectToAction("FullInformation", "Home", new { id = experience.PersonId });
            }

            return View(experience);
        }

        // GET: WorkExperience/Edit/5
        public ActionResult Edit(int id)
        {
            var experience = _unitOfWork.WorkExpireanceRepository.Get(id);
            return View(experience);
        } 

        // POST: WorkExperience/Edit/5
        [HttpPost]
        public ActionResult Edit(WorkExperience experience)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.WorkExpireanceRepository.Edit(experience);
                return RedirectToAction("FullInformation", "Home", new { id = experience.PersonId });
            }

            return View(experience);
        }

        // GET: WorkExperience/Delete/5
        public ActionResult Delete(int idPerson, int idWorkExperience)
        {
            _unitOfWork.WorkExpireanceRepository.Delete(idWorkExperience);
            return RedirectToAction("FullInformation", "Home", new { id = idPerson });
        }
    }
}
