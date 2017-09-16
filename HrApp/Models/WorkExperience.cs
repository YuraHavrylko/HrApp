using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrApp.Models
{
    public class WorkExperience
    {
        [Key]
        public int WorkExperienceId { get; set; }

        [Required]
        [MaxLength(100)]
        public string PositionName { get; set; }

        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? FinishDate { get; set; }

        [Required]
        [ForeignKey("PersonId")]
        public int PersonId { get; set; }
    }
}