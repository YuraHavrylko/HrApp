using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrApp.Infrastructure;
using HrApp.Models;

namespace HrApp.Controllers
{
    public class TypeJobController : Controller
    {
        private UnitOfWork _unitOfWork;

        public TypeJobController()
        {
            _unitOfWork = new UnitOfWork("HRDataBase");
        }
        // GET: TypeJob
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int id)
        {
            var typejob = new TypeJob();
            ViewBag.JobName = _unitOfWork.TypeJobRepository.GetAll();
            typejob.PersonId = id;
            return View(typejob);
        }

        // POST: ProfessionalSkill/Create
        [HttpPost]
        public ActionResult Create(TypeJob job)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TypeJobRepository.Add(job);
                return RedirectToAction("FullInformation", "Home", new { id = job.PersonId });
            }
            ViewBag.JobName = _unitOfWork.JobRepository.GetAll();
            return View(job);
        }

        // GET: ProfessionalSkill/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.JobName = _unitOfWork.TypeJobRepository.GetAll();
            var job = _unitOfWork.TypeJobRepository.Get(id);
            return View(job);
        }

        // POST: ProfessionalSkill/Edit/5
        [HttpPost]
        public ActionResult Edit(TypeJob job)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TypeJobRepository.Edit(job);
                return RedirectToAction("FullInformation", "Home", new { id = job.PersonId });
            }
            ViewBag.JobName = _unitOfWork.TypeJobRepository.GetAll();
            return View(job);
        }

        // GET: ProfessionalSkill/Delete/5
        public ActionResult Delete(int idPerson, int idPersonTypeJob)
        {
            _unitOfWork.TypeJobRepository.Delete(idPersonTypeJob);
            return RedirectToAction("FullInformation", "Home", new { id = idPerson });
        }
    }
}