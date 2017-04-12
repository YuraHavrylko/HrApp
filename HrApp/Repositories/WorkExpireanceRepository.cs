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

        public IEnumerable<WorkExperience> GetAllWhere(WorkExperience experience, int page = 1, int count = 10)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@PersonId", experience.PersonId},
                {"@CompanyName", experience.CompanyName},
                {"@PositionName", experience.PositionName}
            };

            return CustomExecuteReader<WorkExperience>("sp_GetWorkExperiencesWhere", parameters).ToList();
        }

        public void Add(WorkExperience workExperience)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@PersonId", workExperience.PersonId},
                {"@CompanyName", workExperience.CompanyName},
                {"@PositionName", workExperience.PositionName},
                {"@StartDate", workExperience.StartDate},
                {"@FinishDate", workExperience.FinishDate},

            };

            CustomExecuteNonQuery("sp_AddWorkExperience", parameters);
        }

        public void Edit(WorkExperience workExperience)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@WorkExperienceId", workExperience.WorkExperienceId},
                {"@CompanyName", workExperience.CompanyName},
                {"@PositionName", workExperience.PositionName},
                {"@StartDate", workExperience.StartDate},
                {"@FinishDate", workExperience.FinishDate},

            };

            CustomExecuteNonQuery("sp_EditWorkExperience", parameters);
        }

        public void Delete(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@WorkExperienceId", id}
            };

            CustomExecuteNonQuery("sp_DeleteWorkExperience", parameters);
        }
    }
}