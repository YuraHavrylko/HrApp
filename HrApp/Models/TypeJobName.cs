using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HrApp.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class TypeJobsName
    {
        public int? TypeJobId { get; set; }

        [Required]
        [DisplayName("Type job")]
        public string TypeJobName { get; set; }
    }
}