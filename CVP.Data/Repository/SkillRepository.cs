using System.Collections.Generic;
using System.Linq;
using CVP.Domain.Models;
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

        public List<ListSkillDto> GetSkillList()
        {
            return _uow.Skill.Table.Select(s => new ListSkillDto
            {
                Id = s.Id,
                Name = s.Name,
                Score = s.Score
            }).ToList();
        }

        public int UpdateSkill(UpdateSkillDto update)
        {
            _uow.Skill.Update(new Skill
            {
                Id = update.Id,
                Name = update.Name,
                Score = update.Score
            });

            return _uow.SaveChanges();
        }
    }
}
