using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HrApp.Models
{
    public class Person
    {
        public Person()
        {
            Educations = new List<Education>();
            Interviews = new List<Interview>();
            Jobs = new List<Job>();
            ProfessionalSkills = new List<ProfessionalSkill>();
            WorkExperiences = new List<WorkExperience>();
            Languages = new List<Language>();
            PersonTypeJobs = new List<TypeJob>();
        }

        [Key]
        public int PersonId { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }

        public int? Salary { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        public double WorkExpireance { get; set; }

        public ICollection<Education> Educations { get; set; }

        public ICollection<Interview> Interviews { get; set; }

        public ICollection<Language> Languages { get; set; }

        public ICollection<ProfessionalSkill> ProfessionalSkills { get; set; }

        public ICollection<TypeJob> PersonTypeJobs { get; set; }

        public ICollection<WorkExperience> WorkExperiences { get; set; }

        public ICollection<Job> Jobs { get; set; }

        #region SearchPattern

        public int? SalaryStart { get; set; }
        public int? SalaryFinish { get; set; }

        public int? AgeStart { get; set; }
        public int? AgeFinish { get; set; }

        public int? WorkExpireanceStart { get; set; }
        public int? WorkExpireanceFinish { get; set; }

        #endregion

    }   
}