using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Antlr.Runtime.Tree;

namespace HrApp.Models
{
    public class Interview
    {
        [Key]
        public int InterviewId { get; set; }

        [Required]
        public DateTime InterviewTime { get; set; }

        public int? Point { get; set; }

        public string Comment { get; set; }

        public string Resume { get; set; }

        public string Test { get; set; }

        [Required]
        [ForeignKey("PersonId")]
        public int PersonId { get; set; }
    }
}