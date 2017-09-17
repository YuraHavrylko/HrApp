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

        public IEnumerable<Education> GetAllWhere(Education education)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@PersonId", education.PersonId},
                {"@SpecialityName", education.SpecialityName},
                {"@City", education.EducationalInstitutionName}
            };

            return CustomExecuteReader<Education>("sp_GetEducationsWhere", parameters).ToList();
        }

        public void Add(Education person)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(Education person)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Education person)
        {
            throw new System.NotImplementedException();
        }
    }
}