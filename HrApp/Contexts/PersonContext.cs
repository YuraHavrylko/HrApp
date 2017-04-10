using System.Data.Entity;
using HrApp.Models;

namespace HrApp.Contexts
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public DbSet<Education> Educations { get; set; }

        public DbSet<Interview> Interviews { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<LanguageLevel> LanguageLevels { get; set; }

        public DbSet<TypeLanguage> TypeLanguage { get; set; }

        public DbSet<PersonSkill> PersonSkills { get; set; }

        public DbSet<PersonTypeJob> PersonTypeJobs { get; set; }

        public DbSet<ProfessionalSkill> ProfessionalSkills { get; set; }

        public DbSet<TypeJob> TypeJobs { get; set; }

        public DbSet<WorkExperience> WorkExperiences { get; set; }
    }
}