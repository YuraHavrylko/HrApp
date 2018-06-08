using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrApp.Infrastructure;
using HrApp.Models;

namespace HrApp.Controllers
{
    [ClaimsAccess(ClaimType = "access", Value = "typejob:name")]
    public class TypeJobNameController : Controller
    {
        private UnitOfWork _unitOfWork;

        public TypeJobNameController(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            var languages = _unitOfWork.TypeJobsNameRepository.GetAll();
            return View("Index", languages);
        }

        // GET: TypeJobName/Create
        public ActionResult Create()
        {
            var typeJobName = new TypeJobsName();
            return View(typeJobName);
        }

        // POST: TypeJobName/Create
        [HttpPost]
        public ActionResult Create(FormCollection typeJobName)
        {
            var job = typeJobName["TypeJobName"];
            var model = new TypeJobsName() { TypeJobName = job };
            if (ModelState.IsValid)
            {
                _unitOfWork.TypeJobsNameRepository.Add(model);
                return RedirectToAction("Index", "TypeJobName");
            }

            return View(model);
        }

        // GET: TypeJobName/Edit/5
        public ActionResult Edit(int id)
        {
            var typeLanguage = _unitOfWork.TypeJobsNameRepository.Get(id);
            return View(typeLanguage);
        }

        // POST: TypeJobName/Edit/5
        [HttpPost]
        public ActionResult Edit(TypeJobsName typeJobName)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TypeJobsNameRepository.Edit(typeJobName);
                return RedirectToAction("Index", "TypeJobName");
            }

            return View(typeJobName);
        }

        // GET: TypeJobName/Delete/5
        public ActionResult Delete(int typeJobName)
        {
            _unitOfWork.TypeJobsNameRepository.Delete(typeJobName);
            return RedirectToAction("Index", "TypeJobName");
        }
    }
}