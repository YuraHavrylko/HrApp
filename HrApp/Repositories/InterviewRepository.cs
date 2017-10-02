using System.Collections.Generic;
using System.Linq;
using HrApp.Contract;
using HrApp.Contract.Repositories;
using HrApp.Infrastructure;
using HrApp.Models;

namespace HrApp.Repositories
{
    public class InterviewRepository : DbExecuteProvider, IRepository<Interview>
    {
        public InterviewRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public Interview Get(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@InterviewId", id } };

            return CustomExecuteReader<Interview>("sp_GetInterviewById", parameters).FirstOrDefault();
        }

        public IEnumerable<Interview> GetAll()
        {
            return CustomExecuteReader<Interview>("sp_GetInterviews").ToList();
        }

        public IEnumerable<Interview> GetAllWhere(Interview interview, int page = 1, int count = 10)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@PersonId", interview.PersonId}
            };

            return CustomExecuteReader<Interview>("sp_GetInterviewsWhere", parameters).ToList();
        }

        public void Add(Interview interview)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@PersonId", interview.PersonId},
                {"@InterviewDate", interview.InterviewDate},
                {"@Point", interview.Point},
                {"@Comment", interview.Comment},
                {"@FileResume", interview.FileResume},
                {"@FileTest", interview.FileTest}
            };

            CustomExecuteNonQuery("sp_AddInterview", parameters);
        }

        public void Edit(Interview person)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public int GetCountWhere(Interview person)
        {
            throw new System.NotImplementedException();
        }
    }
}