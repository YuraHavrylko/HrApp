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

        public IEnumerable<Interview> GetAllWhere(Interview interview)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@PersonId", interview.PersonId},
                {"@Point", interview.Point}
            };

            return CustomExecuteReader<Interview>("sp_GetInterviewsWhere", parameters).ToList();
        }

        public void Add(Interview person)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(Interview person)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Interview person)
        {
            throw new System.NotImplementedException();
        }
    }
}