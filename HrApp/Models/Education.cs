using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrApp.Models
{
    public class Education
    {
        [Key]
        public int EducationId { get; set; }

        [Required]
        [MaxLength(100)]
        public string SpecialityName { get; set; }

        [Required]
        [MaxLength(200)]
        public string EducationalInstitutionName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? FinishDate { get; set; }

        [Required]
        [ForeignKey("PersonId")]
        public int PersonId { get; set; }
    }
}