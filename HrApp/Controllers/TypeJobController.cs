﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrApp.Infrastructure;
using HrApp.Models;

namespace HrApp.Controllers
{
    [Authorize]
    public class TypeJobController : Controller
    {
        private UnitOfWork _unitOfWork;

        public TypeJobController(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: TypeJob/Create
        public ActionResult Create(int id)
        {
            var typejob = new TypeJob();
            ViewBag.JobName = _unitOfWork.TypeJobsNameRepository.GetAll();
            typejob.PersonId = id;
            return View(typejob);
        }

        // POST: TypeJob/Create
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

        // GET: TypeJob/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.JobName = _unitOfWork.TypeJobRepository.GetAll();
            var job = _unitOfWork.TypeJobRepository.Get(id);
            return View(job);
        }

        // POST: TypeJob/Edit/5
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

        // GET: TypeJob/Delete/5
        public ActionResult Delete(int idPerson, int idPersonTypeJob)
        {
            _unitOfWork.TypeJobRepository.Delete(idPersonTypeJob);
            return RedirectToAction("FullInformation", "Home", new { id = idPerson });
        }
    }
}