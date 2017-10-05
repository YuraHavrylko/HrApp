using System.Collections.Generic;
using System.Linq;
using HrApp.Contract;
using HrApp.Contract.Repositories;
using HrApp.Infrastructure;
using HrApp.Models;

namespace HrApp.Repositories
{
    public class TypeJobRepository : DbExecuteProvider, IRepository<TypeJob>
    {
        public TypeJobRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public TypeJob Get(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@PersonTypeJobId", id } };

            return CustomExecuteReader<TypeJob>("sp_GetTypeJobById", parameters).FirstOrDefault();
        }

        public IEnumerable<TypeJob> GetAll()
        {
            return CustomExecuteReader<TypeJob>("sp_GetTypeJobs").ToList();
        }

        public IEnumerable<TypeJob> GetAllWhere(TypeJob job, int page = 1, int count = 10)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@PersonId", job.PersonId},
                {"@TypeJobName", job.TypeJobName}
            };

            return CustomExecuteReader<TypeJob>("sp_GetTypeJobsWhere", parameters).ToList();
        }

        public void Add(TypeJob typeJob)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@PersonId", typeJob.PersonId},
                {"@TypeJobName", typeJob.TypeJobName}
            };

            CustomExecuteNonQuery("sp_AddTypeJob", parameters);
        }

        public void Edit(TypeJob typeJob)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@PersonTypeJobId", typeJob.PersonTypeJobId},
                {"@TypeJobName", typeJob.TypeJobName}
            };

            CustomExecuteNonQuery("sp_EditTypeJob", parameters);
        }

        public void Delete(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@PersonTypeJobId", id}
            };

            CustomExecuteNonQuery("sp_DeleteTypeJob", parameters);
        }

        public int GetCountWhere(TypeJob person)
        {
            throw new System.NotImplementedException();
        }
    }
}