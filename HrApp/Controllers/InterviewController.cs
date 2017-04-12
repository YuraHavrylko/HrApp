using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrApp.Infrastructure;
using HrApp.Models;

namespace HrApp.Controllers
{
    public class InterviewController : Controller
    {
        private UnitOfWork _unitOfWork;

        public InterviewController()
        {
            _unitOfWork = new UnitOfWork("HRDataBase");
        }

        // GET: Education
        public ActionResult Index()
        {
            return View();
        }

        // GET: Education/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Education/Create
        public ActionResult Create(int id)
        {
            var interview = new Interview();
            interview.PersonId = id;
            return View(interview);
        }

        // POST: Education/Create
        [HttpPost]
        public ActionResult Create(Interview interview, HttpPostedFileBase fileResume, HttpPostedFileBase fileTest)
        {
            if (ModelState.IsValid)
            {
                if (fileResume != null)
                {
                    interview.FileResume = DateTime.Now.ToString("dd.MM.yy-HH.mm") + Path.GetExtension(fileResume.FileName);
                    fileResume.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "Documents/Resumes/" + interview.FileResume);
                }

                if (fileTest != null)
                {
                    interview.FileTest = DateTime.Now.ToString("dd.MM.yy-HH.mm") + Path.GetExtension(fileTest.FileName);
                    fileTest.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "Documents/Tests/" + interview.FileTest);
                }

                _unitOfWork.InterviewRepository.Add(interview);
                return RedirectToAction("FullInformation", "Home", new { id = interview.PersonId });
            }

            return View(interview);
        }

        // GET: Education/Edit/5
        public ActionResult Edit(int id)
        {
            var interview = _unitOfWork.InterviewRepository.Get(id);
            return View(interview);
        }

        // POST: Education/Edit/5
        [HttpPost]
        public ActionResult Edit(Interview interview, HttpPostedFileBase fileResume, HttpPostedFileBase fileTest)
        {
            if (ModelState.IsValid)
            {
                if (fileResume != null)
                {
                    interview.FileResume = DateTime.Now.ToString("dd.MM.yy-HH.mm") + Path.GetExtension(fileResume.FileName);
                    fileResume.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "Documents/Resumes/" + interview.FileResume);
                }

                if (fileTest != null)
                {
                    interview.FileTest = DateTime.Now.ToString("dd.MM.yy-HH.mm") + Path.GetExtension(fileTest.FileName);
                    fileTest.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "Documents/Tests/" + interview.FileTest);
                }

                _unitOfWork.InterviewRepository.Edit(interview);
                return RedirectToAction("FullInformation", "Home", new { id = interview.PersonId });
            }

            return View(interview);
        }

        // GET: Education/Delete/5
        public ActionResult Delete(int idPerson, int idInterview)
        {
            _unitOfWork.InterviewRepository.Delete(idInterview);
            return RedirectToAction("FullInformation", "Home", new { id = idPerson });
        }
    }
}