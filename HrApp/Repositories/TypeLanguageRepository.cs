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
    public class TypeLanguageRepository : DbExecuteProvider, IRepository<TypeLanguage>
    {
        public TypeLanguageRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        //stored procedure not realized 
        public TypeLanguage Get(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@TypeLanguageId", id } };

            return CustomExecuteReader<TypeLanguage>("sp_GetTypeLanguageById", parameters).FirstOrDefault();
        }

        public IEnumerable<TypeLanguage> GetAll()
        {
            return CustomExecuteReader<TypeLanguage>("sp_GetTypeLanguage").ToList();
        }

        //stored procedure not realized 
        public IEnumerable<TypeLanguage> GetAllWhere(TypeLanguage languagesName, int page = 1, int count = 10)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@TypeLanguageId", languagesName.TypeLanguageId},
                {"@LanguageName", languagesName.LanguageName}
            };

            return CustomExecuteReader<TypeLanguage>("sp_GetTypeLanguageWhere", parameters).ToList();
        }

        //stored procedure not realized 
        public void Add(TypeLanguage languagesName)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@TypeLanguageId", languagesName.TypeLanguageId},
                {"@LanguageName", languagesName.LanguageName}
            };

            CustomExecuteNonQuery("sp_AddTypeLanguage", parameters);
        }

        public void Edit(TypeLanguage person)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}