using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrApp.Infrastructure;
using HrApp.Models;

namespace HrApp.Controllers
{
    public class ProfessionalSkillController : Controller
    {
        private UnitOfWork _unitOfWork;

        public ProfessionalSkillController(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: ProfessionalSkill/Create
        public ActionResult Create(int id)
        {
            var skill = new ProfessionalSkill();
            skill.PersonId = id;
            return View(skill);
        }

        // POST: ProfessionalSkill/Create
        [HttpPost]
        public ActionResult Create(ProfessionalSkill skill)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ProfessionalSkillRepository.Add(skill);
                return RedirectToAction("FullInformation", "Home", new { id = skill.PersonId });
            }

            return View("Create", skill);
        }

        // GET: ProfessionalSkill/Edit/5
        public ActionResult Edit(int id)
        {
            var skill = _unitOfWork.ProfessionalSkillRepository.Get(id);
            return View(skill);
        }

        // POST: ProfessionalSkill/Edit/5
        [HttpPost]
        public ActionResult Edit(ProfessionalSkill skill)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ProfessionalSkillRepository.Edit(skill);
                return RedirectToAction("FullInformation", "Home", new { id = skill.PersonId });
            }

            return View(skill);
        }

        // GET: ProfessionalSkill/Delete/5
        public ActionResult Delete(int idPerson, int idSkill)
        {
            _unitOfWork.ProfessionalSkillRepository.Delete(idSkill);
            return RedirectToAction("FullInformation", "Home", new { id = idPerson });
        }
    }
}