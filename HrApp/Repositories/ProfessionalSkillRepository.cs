﻿using System.Collections.Generic;
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

        public IEnumerable<ProfessionalSkill> GetAllWhere(ProfessionalSkill skill)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@PersonId", skill.PersonId},
                {"@SkillName", skill.SkillName}
            };

            return CustomExecuteReader<ProfessionalSkill>("sp_GetProfessionalSkillsWhere", parameters).ToList();
        }

        public void Add(ProfessionalSkill person)
        {
            throw new System.NotImplementedException();
        }

        public void Edit(ProfessionalSkill person)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(ProfessionalSkill person)
        {
            throw new System.NotImplementedException();
        }
    }
}