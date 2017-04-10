using System.Collections.Generic;
using System.Data;
using System.Linq;
using HrApp.Contract;
using HrApp.Contract.Repositories;
using HrApp.Infrastructure;
using HrApp.Models;

namespace HrApp.Repositories
{
    public class PersonRepository : DbExecuteProvider
    {
        public PersonRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public Person Get(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object> {{"@PersonId", id}};
            var list = CustomExecuteReader("sp_GetPersonById", parameters);

            return list.FirstOrDefault();
        }

        public IEnumerable<Person> GetAll(int page = 1, int count = 10)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@Page", page},
                {"@Count", count}
            };
            var list = CustomExecuteReader("sp_GetPersons", parameters);

            return list;
        }

        public IEnumerable<Person> GetAllWhere(Person person = null, Education education = null,
            Interview interview = null, Job job = null, Language language = null, TypeJob typeJob = null,
            WorkExperience experience = null, ProfessionalSkill professionalSkill = null, int page = 1, int count = 10)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@Page", page},
                {"@Count", count}
            };

            if (person != null)
            {
                parameters.Add("@PersonId", person.PersonId);
                parameters.Add("@FirstName", person.FirstName);
                parameters.Add("@LastName", person.LastName);
                parameters.Add("@AgeStart", person.AgeStart);
                parameters.Add("@AgeFinish", person.AgeFinish);
                parameters.Add("@City", person.City);
                parameters.Add("@Email", person.Email);
                parameters.Add("@Phone", person.Phone);
                parameters.Add("@SalaryStart", person.SalaryStart);
                parameters.Add("@SalaryFinish", person.SalaryFinish);
                parameters.Add("@WorkExpireanceStart", person.WorkExpireanceStart);
                parameters.Add("@WorkExpireanceFinish", person.WorkExpireanceFinish);
            }

            if (education != null)
            {
                parameters.Add("@SpecialityName", education.SpecialityName);
                parameters.Add("@EducationalInstitutionName", education.EducationalInstitutionName);
                parameters.Add("@EducationStartDate", education.StartDate);
                parameters.Add("@EducationFinishDate", education.FinishDate);
            }

            if (interview != null)
            {
                parameters.Add("@InterviewDate", interview.InterviewDate);
            }

            if (language != null)
            {
                parameters.Add("@LanguageName", language.LanguageName);
                parameters.Add("@LanguageLevelName", language.LanguageLevelName);
            }

            if (job != null)
            {
                parameters.Add("@JobName", job.JobName);
            }

            if (typeJob != null)
            {
                parameters.Add("@TypeJobName", typeJob.TypeJobName);
            }

            if (experience != null)
            {
                parameters.Add("@PositionName", experience.PositionName);
                parameters.Add("@CompanyName", experience.CompanyName);
                parameters.Add("@ExperienceStartDate", experience.StartDate);
                parameters.Add("@ExperienceFinishDate", experience.FinishDate);
            }

            if (professionalSkill != null)
            {
                parameters.Add("@SkillName", professionalSkill.SkillName);
            }

            var list = CustomExecuteReader("sp_GetPersonsWhere", parameters);

            return list;
        }

        public void Add(Person person)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@FirstName", person.FirstName},
                {"@LastName", person.LastName},
                {"@Birthday", person.Birthday},
                {"@City", person.City},
                {"@Email", person.Email},
                {"@Phone", person.Phone},
                {"@Salary", person.Salary},
                {"@WorkExpireance", person.WorkExpireance},
            };

            CustomExecuteNonQuery("sp_AddPerson", parameters);
        }

        public void Edit(Person person)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@PersonId", person.PersonId},
                {"@FirstName", person.FirstName},
                {"@LastName", person.LastName},
                {"@Birthday", person.Birthday},
                {"@City", person.City},
                {"@Email", person.Email},
                {"@Phone", person.Phone},
                {"@Salary", person.Salary},
                {"@WorkExpireance", person.WorkExpireance},
            };

            CustomExecuteNonQuery("sp_EditPerson", parameters);
        }

        public void Delete(int person)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@PersonId", person}
            };

            CustomExecuteNonQuery("sp_DeletePerson", parameters);
        }

        public int GetCountWhere(Person person = null, Education education = null,
            Interview interview = null, Job job = null, Language language = null, TypeJob typeJob = null,
            WorkExperience experience = null, ProfessionalSkill professionalSkill = null)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            if (person != null)
            {
                parameters.Add("@PersonId", person.PersonId);
                parameters.Add("@FirstName", person.FirstName);
                parameters.Add("@LastName", person.LastName);
                parameters.Add("@AgeStart", person.AgeStart);
                parameters.Add("@AgeFinish", person.AgeFinish);
                parameters.Add("@City", person.City);
                parameters.Add("@Email", person.Email);
                parameters.Add("@Phone", person.Phone);
                parameters.Add("@SalaryStart", person.SalaryStart);
                parameters.Add("@SalaryFinish", person.SalaryFinish);
                parameters.Add("@WorkExpireanceStart", person.WorkExpireanceStart);
                parameters.Add("@WorkExpireanceFinish", person.WorkExpireanceFinish);
            }

            if (education != null)
            {
                parameters.Add("@SpecialityName", education.SpecialityName);
                parameters.Add("@EducationalInstitutionName", education.EducationalInstitutionName);
                parameters.Add("@EducationStartDate", education.StartDate);
                parameters.Add("@EducationFinishDate", education.FinishDate);
            }

            if (interview != null)
            {
                parameters.Add("@InterviewDate", interview.InterviewDate);
            }

            if (language != null)
            {
                parameters.Add("@LanguageName", language.LanguageName);
                parameters.Add("@LanguageLevelName", language.LanguageLevelName);
            }

            if (job != null)
            {
                parameters.Add("@JobName", job.JobName);
            }

            if (typeJob != null)
            {
                parameters.Add("@TypeJobName", typeJob.TypeJobName);
            }

            if (experience != null)
            {
                parameters.Add("@PositionName", experience.PositionName);
                parameters.Add("@CompanyName", experience.CompanyName);
                parameters.Add("@ExperienceStartDate", experience.StartDate);
                parameters.Add("@ExperienceFinishDate", experience.FinishDate);
            }

            if (professionalSkill != null)
            {
                parameters.Add("@SkillName", professionalSkill.SkillName);
            }

            return (int) CustomExecuteScalar("sp_GetCountPersonsWhere", parameters);
        }

        public int GetCount()
        {
            return (int)CustomExecuteScalar("sp_GetCountPersons");
        }
    }
}