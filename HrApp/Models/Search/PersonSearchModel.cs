using System.Collections.Generic;

namespace HrApp.Models.Search
{
    public class PersonSearchModel
    {
        public PersonSearchModel()
        {
            TypeLanguage = new TypeLanguage();
            LanguageLevel = new LanguageLevel();
            TypeJob = new TypeJob();
        }

        public int? PersonId { get; set; }
        public string ApplicationUserId { get; set; }
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string City { get; set; }

        public int? SalaryStart { get; set; }
        public int? SalaryFinish { get; set; }

        public int? AgeStart { get; set; }
        public int? AgeFinish { get; set; }

        public int? WorkExpireanceStart { get; set; }
        public int? WorkExpireanceFinish { get; set; }

        public Education Education { get; set; }

        public InterviewSearchModel Interview { get; set; }

        public Job Job { get; set; }

        public TypeLanguage TypeLanguage { get; set; }

        public LanguageLevel LanguageLevel { get; set; }

        public ProfessionalSkill ProfessionalSkill { get; set; }

        public TypeJob TypeJob { get; set; }

        public WorkExperience WorkExperience { get; set; }

        public ICollection<TypeLanguage> TypeLanguages { get; set; }

        public ICollection<LanguageLevel> LanguageLevels { get; set; }

        public ICollection<TypeJobsName> TypeJobsNames { get; set; }
    }
}