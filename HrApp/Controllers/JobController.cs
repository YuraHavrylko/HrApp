using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrApp.Infrastructure;
using HrApp.Models;

namespace HrApp.Controllers
{
    [Authorize]
    public class JobController : Controller
    {
        private UnitOfWork _unitOfWork;

        public JobController(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: Job/Create
        public ActionResult Create(int id)
        {
            var education = new Job();
            education.PersonId = id;
            return View(education);
        }

        // POST: Job/Create
        [HttpPost]
        public ActionResult Create(Job job)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.JobRepository.Add(job);
                return RedirectToAction("FullInformation", "Home", new { id = job.PersonId });
            }

            return View(job);
        }

        // GET: Job/Edit/5
        public ActionResult Edit(int id)
        {
            var education = _unitOfWork.JobRepository.Get(id);
            return View(education);
        }

        // POST: Job/Edit/5
        [HttpPost]
        public ActionResult Edit(Job job)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.JobRepository.Edit(job);
                return RedirectToAction("FullInformation", "Home", new { id = job.PersonId });
            }

            return View(job);
        }

        // GET: Job/Delete/5
        public ActionResult Delete(int idPerson, int idJob)
        {
            _unitOfWork.JobRepository.Delete(idJob);
            return RedirectToAction("FullInformation", "Home", new { id = idPerson });
        }
    }
}