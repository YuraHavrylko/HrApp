using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HrApp.Models
{
    public class Person
    {
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

        public int Salary { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        public double WorkExpireance { get; set; }

        public ICollection<Education> Educations { get; set; }

        public ICollection<Interview> Interviews { get; set; }

        public ICollection<Language> Languages { get; set; }

        public ICollection<ProfessionalSkill> ProfessionalSkills { get; set; }

        public ICollection<PersonTypeJob> PersonTypeJobs { get; set; }

        public ICollection<WorkExperience> WorkExperiences { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }   
}