using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrApp.Infrastructure;
using HrApp.Models;

namespace HrApp.Controllers
{
    public class LanguageController : Controller
    {
        private UnitOfWork _unitOfWork;

        public LanguageController()
        {
            _unitOfWork = new UnitOfWork("HRDataBase");
        }

        // GET: Language/Create
        public ActionResult Create(int id)
        {
            var language = new Language();
            ViewBag.LanguageName = _unitOfWork.LanguagesNameRepository.GetAll();
            ViewBag.LanguageLevel = _unitOfWork.LanguageLevelRepository.GetAll();
            language.PersonId = id;
            return View(language);
        }

        // POST: Language/Create
        [HttpPost]
        public ActionResult Create(Language language)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.LanguageRepository.Add(language);
                return RedirectToAction("FullInformation", "Home", new { id = language.PersonId });
            }
            ViewBag.LanguageName = _unitOfWork.LanguagesNameRepository.GetAll();
            ViewBag.LanguageLevel = _unitOfWork.LanguageLevelRepository.GetAll();
            return View(language);
        }

        // GET: Language/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.LanguageName = _unitOfWork.LanguagesNameRepository.GetAll();
            ViewBag.LanguageLevel = _unitOfWork.LanguageLevelRepository.GetAll();
            var language = _unitOfWork.LanguageRepository.Get(id);
            return View(language);
        }

        // POST: Language/Edit/5
        [HttpPost]
        public ActionResult Edit(Language language)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.LanguageRepository.Edit(language);
                return RedirectToAction("FullInformation", "Home", new { id = language.PersonId });
            }
            ViewBag.LanguageName = _unitOfWork.LanguagesNameRepository.GetAll();
            ViewBag.LanguageLevel = _unitOfWork.LanguageLevelRepository.GetAll();
            return View(language);
        }

        // GET: Language/Delete/5
        public ActionResult Delete(int idPerson, int idLanguage)
        {
            _unitOfWork.LanguageRepository.Delete(idLanguage);
            return RedirectToAction("FullInformation", "Home", new { id = idPerson });
        }
    }
}