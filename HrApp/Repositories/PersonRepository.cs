using System.Collections.Generic;
using System.Data;
using System.Linq;
using HrApp.Contract;
using HrApp.Contract.Repositories;
using HrApp.Infrastructure;
using HrApp.Models;
using HrApp.Models.Search;

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

        public IEnumerable<Person> GetAllWhere(PersonSearchModel person = null, int page = 1, int count = 10)
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

                if (person.Education != null)
                {
                    parameters.Add("@SpecialityName", person.Education.SpecialityName);
                    parameters.Add("@EducationalInstitutionName", person.Education.EducationalInstitutionName);
                    parameters.Add("@EducationStartDate", person.Education.StartDate);
                    parameters.Add("@EducationFinishDate", person.Education.FinishDate);
                }

                if (person.Interview != null)
                {
                    parameters.Add("@InterviewStartDate", person.Interview.InterviewStartDate);
                    parameters.Add("@InterviewFinishDate", person.Interview.InterviewFinishDate);
                }

                if (person.TypeLanguage != null)
                {
                    parameters.Add("@LanguageName", person.TypeLanguage.LanguageName);
                    
                }
                if (person.LanguageLevel != null)
                {
                    parameters.Add("@LanguageLevelName", person.LanguageLevel.LanguageLevelName);
                }
                if (person.Job != null)
                {
                    parameters.Add("@JobName", person.Job.JobName);
                }

                if (person.TypeJob != null)
                {
                    parameters.Add("@TypeJobName", person.TypeJob.TypeJobName);
                }

                if (person.WorkExperience != null)
                {
                    parameters.Add("@PositionName", person.WorkExperience.PositionName);
                    parameters.Add("@CompanyName", person.WorkExperience.CompanyName);
                    parameters.Add("@ExperienceStartDate", person.WorkExperience.StartDate);
                    parameters.Add("@ExperienceFinishDate", person.WorkExperience.FinishDate);
                }

                if (person.ProfessionalSkill != null)
                {
                    parameters.Add("@SkillName", person.ProfessionalSkill.SkillName);
                }
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

        public void Delete(int? person)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@PersonId", person}
            };

            CustomExecuteNonQuery("sp_DeletePerson", parameters);
        }

        public int GetCountWhere(PersonSearchModel person = null)
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

                if (person.Education != null)
                {
                    parameters.Add("@SpecialityName", person.Education.SpecialityName);
                    parameters.Add("@EducationalInstitutionName", person.Education.EducationalInstitutionName);
                    parameters.Add("@EducationStartDate", person.Education.StartDate);
                    parameters.Add("@EducationFinishDate", person.Education.FinishDate);
                }

                if (person.Interview != null)
                {
                    parameters.Add("@InterviewStartDate", person.Interview.InterviewStartDate);
                    parameters.Add("@InterviewFinishDate", person.Interview.InterviewFinishDate);
                }

                if (person.TypeLanguage != null)
                {
                    parameters.Add("@LanguageName", person.TypeLanguage.LanguageName);

                }
                if (person.LanguageLevel != null)
                {
                    parameters.Add("@LanguageLevelName", person.LanguageLevel.LanguageLevelName);
                }

                if (person.Job != null)
                {
                    parameters.Add("@JobName", person.Job.JobName);
                }

                if (person.TypeJob != null)
                {
                    parameters.Add("@TypeJobName", person.TypeJob.TypeJobName);
                }

                if (person.WorkExperience != null)
                {
                    parameters.Add("@PositionName", person.WorkExperience.PositionName);
                    parameters.Add("@CompanyName", person.WorkExperience.CompanyName);
                    parameters.Add("@ExperienceStartDate", person.WorkExperience.StartDate);
                    parameters.Add("@ExperienceFinishDate", person.WorkExperience.FinishDate);
                }

                if (person.ProfessionalSkill != null)
                {
                    parameters.Add("@SkillName", person.ProfessionalSkill.SkillName);
                }
            }

            return (int) CustomExecuteScalar("sp_GetCountPersonsWhere", parameters);
        }

        public int GetCount()
        {
            return (int)CustomExecuteScalar("sp_GetCountPersons");
        }
    }
}