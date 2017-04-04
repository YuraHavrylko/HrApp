using System.Collections.Generic;
using System.Linq;
using HrApp.Contract;
using HrApp.Contract.Repositories;
using HrApp.Infrastructure;
using HrApp.Models;

namespace HrApp.Repositories
{
    public class WorkExpireanceRepository : DbExecuteProvider, IRepository<WorkExperience>
    {
        public WorkExpireanceRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public WorkExperience Get(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@WorkExperienceId", id } };

            return CustomExecuteReader<WorkExperience>("sp_GetWorkExperienceById", parameters).FirstOrDefault();
        }

        public IEnumerable<WorkExperience> GetAll()
        {
            return CustomExecuteReader<WorkExperience>("sp_GetWorkExperiences").ToList();
        }

        public IEnumerable<WorkExperience> GetAllWhere(WorkExperience experience)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@PersonId", experience.PersonId},
                {"@CompanyName", experience.CompanyName},
                {"@CompanyName", experience.CompanyName}
            };

            return CustomExecuteReader<WorkExperience>("sp_GetWorkExperiencesWhere", parameters).ToList();
        }

        public void Add(WorkExperience person)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(WorkExperience person)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(WorkExperience person)
        {
            throw new System.NotImplementedException();
        }
    }
}