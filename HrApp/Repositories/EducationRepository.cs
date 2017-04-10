using System.Collections.Generic;
using System.Linq;
using HrApp.Contract;
using HrApp.Contract.Repositories;
using HrApp.Infrastructure;
using HrApp.Models;

namespace HrApp.Repositories
{
    public class EducationRepository : DbExecuteProvider, IRepository<Education>
    {
        public EducationRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public Education Get(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@EducationId", id } };

            return CustomExecuteReader<Education>("sp_GetEducationById", parameters).FirstOrDefault();
        }

        public IEnumerable<Education> GetAll()
        {
            return CustomExecuteReader<Education>("sp_GetEducations").ToList();
        }

        public IEnumerable<Education> GetAllWhere(Education education, int page = 1, int count = 10)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@PersonId", education.PersonId},
                {"@SpecialityName", education.SpecialityName},
                {"@EducationalInstitutionName", education.EducationalInstitutionName}
            };

            return CustomExecuteReader<Education>("sp_GetEducationsWhere", parameters).ToList();
        }

        public void Add(Education education)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@PersonId", education.PersonId},
                {"@SpecialityName", education.SpecialityName},
                {"@EducationalInstitutionName", education.EducationalInstitutionName},
                {"@StartDate", education.StartDate},
                {"@FinishDate", education.FinishDate}
            };

            CustomExecuteNonQuery("sp_AddEducation", parameters);
        }

        public void Edit(Education education)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@EducationId", education.EducationId},
                {"@SpecialityName", education.SpecialityName},
                {"@EducationalInstitutionName", education.EducationalInstitutionName},
                {"@StartDate", education.StartDate},
                {"@FinishDate", education.FinishDate}
            };

            CustomExecuteNonQuery("sp_EditEducation", parameters);
        }

        public void Delete(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@EducationId", id}
            };

            CustomExecuteNonQuery("sp_DeleteEducation", parameters);
        }

        public int GetCountWhere(Education person)
        {
            throw new System.NotImplementedException();
        }
    }
}