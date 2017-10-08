using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HrApp.Models.Search;

namespace HrApp.Models
{
    public class BigPersonModel
    {
        public IEnumerable<Person> Persons { get; set; }
        public PersonSearchModel PersonSearchModel { get; set; }

        public BigPersonModel()
        {
            Persons = new List<Person>();
            PersonSearchModel = new PersonSearchModel();
        }
    }
}