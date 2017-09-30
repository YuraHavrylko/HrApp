using System.Collections.Generic;
using System.Linq;
using HrApp.Contract;
using HrApp.Contract.Repositories;
using HrApp.Infrastructure;
using HrApp.Models;

namespace HrApp.Repositories
{
    public class LanguageRepository : DbExecuteProvider, IRepository<Language>
    {
        public LanguageRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public Language Get(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@LanguageId", id } };

            return CustomExecuteReader<Language>("sp_GetLanguageById", parameters).FirstOrDefault();
        }

        public IEnumerable<Language> GetAll()
        {
            return CustomExecuteReader<Language>("sp_GetLanguages").ToList();
        }

        public IEnumerable<Language> GetAllWhere(Language language, int page = 1, int count = 10)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@PersonId", language.PersonId},
                {"@LanguageName", language.LanguageName},
                {"@LanguageLevelName", language.LanguageLevelName}
            };

            return CustomExecuteReader<Language>("sp_GetLanguagesWhere", parameters).ToList();
        }

        public void Add(Language language)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@PersonId", language.PersonId},
                {"@LanguageLevelName", language.LanguageLevelName},
                {"@LanguageName", language.LanguageName}
            };

            CustomExecuteNonQuery("sp_AddLanguage", parameters);
        }

        public void Edit(Language person)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Language person)
        {
            throw new System.NotImplementedException();
        }

        public int GetCountWhere(Language person)
        {
            throw new System.NotImplementedException();
        }
    }
}