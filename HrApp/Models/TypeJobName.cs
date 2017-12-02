using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrApp.Models
{
    using System.ComponentModel;

    public class TypeJobsName
    {
        public int? TypeJobId { get; set; }

        [DisplayName("Type job")]
        public string TypeJobName { get; set; }
    }
}