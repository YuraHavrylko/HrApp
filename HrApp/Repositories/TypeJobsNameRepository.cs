using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HrApp.Contract;
using HrApp.Contract.Repositories;
using HrApp.Infrastructure;
using HrApp.Models;

namespace HrApp.Repositories
{
    public class TypeJobsNameRepository : DbExecuteProvider, IRepository<TypeJobsName>
    {
        public TypeJobsNameRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        //stored procedure not realized 
        public TypeJobsName Get(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@TypeLanguageId", id } };

            return CustomExecuteReader<TypeJobsName>("sp_GetTypeJobsNameById", parameters).FirstOrDefault();
        }

        public IEnumerable<TypeJobsName> GetAll()
        {
            return CustomExecuteReader<TypeJobsName>("sp_GetTypeJobsName").ToList();
        }

        //stored procedure not realized 
        public IEnumerable<TypeJobsName> GetAllWhere(TypeJobsName typeJobsName, int page = 1, int count = 10)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@TypeJobsNameId", typeJobsName.TypeJobId},
                {"@TypeJobName", typeJobsName.TypeJobName}
            };

            return CustomExecuteReader<TypeJobsName>("sp_GetTypeJobsNameWhere", parameters).ToList();
        }

        public IEnumerable<TypeJobsName> Get(Func<TypeJobsName, bool> predicate)
        {
            throw new NotImplementedException();
        }

        //stored procedure not realized 
        public void Add(TypeJobsName typeJobsName)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@TypeJobName", typeJobsName.TypeJobName}
            };

            CustomExecuteNonQuery("sp_AddTypeJobsName", parameters);
        }

        public void Edit(TypeJobsName typeJobsName)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@TypeJobsNameId", typeJobsName.TypeJobId},
                {"@TypeJobName", typeJobsName.TypeJobName}
            };

            CustomExecuteNonQuery("sp_EditTypeJobsName", parameters);
        }

        public void Delete(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@TypeJobsNameId", id}
            };

            CustomExecuteNonQuery("sp_DeleteTypeJobsName", parameters);
        }
    }
}