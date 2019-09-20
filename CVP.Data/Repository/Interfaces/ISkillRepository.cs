using CVP.Data.Models;
using CVP.Domain.Dtos.Skill;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVP.Data.Repository.Interfaces
{
    public interface ISkillRepository
    {
        int AddSkill(AddSkillDto add);
        List<ListSkillDto> GetSkillList();
    }
}
