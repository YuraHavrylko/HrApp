using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrApp.Infrastructure;
using HrApp.Models;

namespace HrApp.Controllers
{

    public class EducationController : Controller
    {
        private UnitOfWork _unitOfWork;

        public EducationController(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: Education/Create
        public ActionResult Create(int id)
        {
            var education = new Education();
            education.PersonId = id;
            return View(education);
        }

        // POST: Education/Create
        [HttpPost]
        public ActionResult Create(Education education)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.EducationRepository.Add(education);
                return RedirectToAction("FullInformation", "Home", new {id = education.PersonId});
            }

            return View(education);
        }

        // GET: Education/Edit/5
        public ActionResult Edit(int id)
        {
            var education = _unitOfWork.EducationRepository.Get(id);
            return View(education);
        }

        // POST: Education/Edit/5
        [HttpPost]
        public ActionResult Edit(Education education)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.EducationRepository.Edit(education);
                return RedirectToAction("FullInformation", "Home", new { id = education.PersonId });
            }

            return View(education);
        }

        // GET: Education/Delete/5
        public ActionResult Delete(int idPerson, int idEducation)
        {
            _unitOfWork.EducationRepository.Delete(idEducation);
            return RedirectToAction("FullInformation", "Home", new { id = idPerson });
        }

    }
}
