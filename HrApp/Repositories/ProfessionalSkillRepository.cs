using System.Collections.Generic;
using System.Linq;
using HrApp.Contract;
using HrApp.Contract.Repositories;
using HrApp.Infrastructure;
using HrApp.Models;

namespace HrApp.Repositories
{
    public class ProfessionalSkillRepository : DbExecuteProvider, IRepository<ProfessionalSkill>
    {
        public ProfessionalSkillRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public ProfessionalSkill Get(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object> { { "@ProfessionalSkillId", id } };

            return CustomExecuteReader<ProfessionalSkill>("sp_GetProfessionalSkillById", parameters).FirstOrDefault();
        }

        public IEnumerable<ProfessionalSkill> GetAll()
        {
            return CustomExecuteReader<ProfessionalSkill>("sp_GetProfessionalSkills").ToList();
        }

        public IEnumerable<ProfessionalSkill> GetAllWhere(ProfessionalSkill skill, int page = 1, int count = 10)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@PersonId", skill.PersonId},
                {"@SkillName", skill.SkillName}
            };

            return CustomExecuteReader<ProfessionalSkill>("sp_GetProfessionalSkillsWhere", parameters).ToList();
        }

        public void Add(ProfessionalSkill professionalSkill)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@PersonId", professionalSkill.PersonId},
                {"@SkillName", professionalSkill.SkillName}
            };

            CustomExecuteNonQuery("sp_AddProfessionalSkill", parameters);
        }

        public void Edit(ProfessionalSkill professionalSkill)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@ProfessionalSkillId", professionalSkill.ProfessionalSkillId},
                {"@SkillName", professionalSkill.SkillName}
            };

            CustomExecuteNonQuery("sp_EditProfessionalSkill", parameters);
        }

        public void Delete(int id)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@ProfessionalSkillId", id}
            };

            CustomExecuteNonQuery("sp_DeleteProfessionalSkill", parameters);
        }
    }
}