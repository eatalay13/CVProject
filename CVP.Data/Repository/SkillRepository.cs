using CVP.Data.Repository.Interfaces;
using CVP.Data.Uow;
using CVP.Domain.Dtos.Skill;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVP.Data.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly IUnitOfWork _uow;

        public SkillRepository(IUnitOfWork uow)
        {
            this._uow = uow;
        }
        public void AddSkill(AddSkillDto add)
        {
            _uow.Skill.Insert(new Models.Skill
            {
                Name = add.Name,
                Score = add.Score
            });
        }
    }
}
