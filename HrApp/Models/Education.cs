using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrApp.Models
{
    using System.ComponentModel;

    public class Education
    {
        [Key]
        public int EducationId { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("Specialty")]
        public string SpecialityName { get; set; }

        [Required]
        [MaxLength(200)]
        [DisplayName("Institution name")]
        public string EducationalInstitutionName { get; set; }

        [DisplayName("Start date")]
        public DateTime? StartDate { get; set; }

        [DisplayName("Finish date")]
        public DateTime? FinishDate { get; set; }

        [Required]
        [ForeignKey("PersonId")]
        public int PersonId { get; set; }
    }
}