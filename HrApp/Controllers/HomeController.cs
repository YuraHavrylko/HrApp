using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HrApp.Infrastructure;
using HrApp.Models;
using HrApp.Repositories;

namespace HrApp.Controllers
{
    public class HomeController : Controller
    {
        private PersonRepository _personRepository;
        public ActionResult Index()
        {
            _personRepository = new PersonRepository(new DbConnectionFactory("HRDataBase"));
            var peson = _personRepository.GetAllWhere(new Person() {LastName = "a"});
            return View();
        }
        
        public ActionResult FullInformation()
        {
            return View();
        }
    }
}