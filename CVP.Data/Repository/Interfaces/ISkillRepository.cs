using CVP.Domain.Dtos.Skill;
using System.Collections.Generic;

namespace CVP.Data.Repository.Interfaces
{
    public interface ISkillRepository
    {
        int AddSkill(AddSkillDto add);
        List<ListSkillDto> GetSkillList();
        int UpdateSkill(UpdateSkillDto update);
    }
}
