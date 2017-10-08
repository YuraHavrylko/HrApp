using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrApp.Infrastructure;
using HrApp.Models;

namespace HrApp.Controllers
{
    public class LevelLanguageController : Controller
    {
        private UnitOfWork _unitOfWork;

        public LevelLanguageController()
        {
            _unitOfWork = new UnitOfWork("HRDataBase");
        }

        public ActionResult Index()
        {
            var languages = _unitOfWork.LanguageLevelRepository.GetAll();
            return View("Index", languages);
        }

        // GET: LevelLanguage/Create
        public ActionResult Create()
        {
            var languageLevel = new LanguageLevel();
            return View(languageLevel);
        }

        // POST: LevelLanguage/Create
        [HttpPost]
        public ActionResult Create(LanguageLevel language)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.LanguageLevelRepository.Add(language);
                return RedirectToAction("Index", "Home");
            }

            return View(language);
        }

        // GET: LevelLanguage/Edit/5
        public ActionResult Edit(int id)
        {
            var typeLanguage = _unitOfWork.LanguageLevelRepository.Get(id);
            return View(typeLanguage);
        }

        // POST: LevelLanguage/Edit/5
        [HttpPost]
        public ActionResult Edit(LanguageLevel language)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.LanguageLevelRepository.Edit(language);
                return RedirectToAction("FullInformation", "Home");
            }

            return View(language);
        }

        // GET: LevelLanguage/Delete/5
        public ActionResult Delete(int levelLanguage)
        {
            _unitOfWork.LanguageLevelRepository.Delete(levelLanguage);
            return RedirectToAction("FullInformation", "Home");
        }
    }
}