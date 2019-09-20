using System.Collections.Generic;
using CVP.Data.Models;
using CVP.Data.Repository.Interfaces;
using CVP.Data.Uow;
using CVP.Domain.Dtos.Skill;

namespace CVP.Data.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly IUnitOfWork _uow;

        public SkillRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public int AddSkill(AddSkillDto add)
        {
            _uow.Skill.Insert(new Skill
            {
                Name = add.Name,
                Score = add.Score
            });

            return _uow.SaveChanges();
        }

        public List<Skill> GetSkillList()
        {
            return _uow.Skill.GetList();
        }
    }
}
