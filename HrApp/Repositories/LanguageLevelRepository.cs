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
    public class LanguageLevelRepository : DbExecuteProvider, IRepository<LanguageLevel>
    {
        public LanguageLevelRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        //stored procedure not realized 
        public LanguageLevel Get(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@LanguageLevelId", id } };

            return CustomExecuteReader<LanguageLevel>("sp_GetLanguageLevelById", parameters).FirstOrDefault();
        }

        public IEnumerable<LanguageLevel> GetAll()
        {
            return CustomExecuteReader<LanguageLevel>("sp_GetLanguageLevel").ToList();
        }

        //stored procedure not realized 
        public IEnumerable<LanguageLevel> GetAllWhere(LanguageLevel languageLevel, int page = 1, int count = 10)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@LanguageLevelId", languageLevel.LanguageLevelId},
                {"@LanguageLevelName", languageLevel.LanguageLevelName}
            };

            return CustomExecuteReader<LanguageLevel>("sp_GetLanguageLevelWhere", parameters).ToList();
        }

        //stored procedure not realized 
        public void Add(LanguageLevel languageLevel)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@LanguageLevelId", languageLevel.LanguageLevelId},
                {"@LanguageLevelName", languageLevel.LanguageLevelName}
            };

            CustomExecuteNonQuery("sp_AddLanguageLevel", parameters);
        }

        public void Edit(LanguageLevel languageLevel)
        {
            throw new System.NotImplementedException();
        }

        public int GetCountWhere(LanguageLevel languageLevel)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}