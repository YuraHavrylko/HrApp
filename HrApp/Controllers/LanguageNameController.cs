using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrApp.Infrastructure;
using HrApp.Models;

namespace HrApp.Controllers
{
    public class LanguageNameController : Controller
    {

        private UnitOfWork _unitOfWork;

        public LanguageNameController(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: LanguageName
        public ActionResult Index()
        {
            var languages = _unitOfWork.LanguagesNameRepository.GetAll();
            return View("Index", languages);
        }

        // GET: LanguageName/Create
        public ActionResult Create()
        {
            var typeLanguage = new TypeLanguage();
            return View(typeLanguage);
        }

        // POST: LanguageName/Create
        [HttpPost]
        public ActionResult Create(TypeLanguage language)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.LanguagesNameRepository.Add(language);
                return RedirectToAction("Index", "LanguageName");
            }

            return View(language);
        }

        // GET: LanguageName/Edit/5
        public ActionResult Edit(int id)
        {
            var typeLanguage = _unitOfWork.LanguagesNameRepository.Get(id);
            return View(typeLanguage);
        }

        // POST: LanguageName/Edit/5
        [HttpPost]
        public ActionResult Edit(TypeLanguage typeLanguage)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.LanguagesNameRepository.Edit(typeLanguage);
                return RedirectToAction("Index", "LanguageName");
            }

            return View(typeLanguage);
        }

        // GET: LanguageName/Delete/5
        public ActionResult Delete(int typeLanguage)
        {
            _unitOfWork.LanguagesNameRepository.Delete(typeLanguage);
            return RedirectToAction("Index", "LanguageName");
        }
    }
}