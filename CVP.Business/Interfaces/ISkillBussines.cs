using CVP.Domain.Contracts.Skill.Requests;
using CVP.Domain.Contracts.Skill.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVP.Business.Interfaces
{
    public interface ISkillBussines
    {
        AddSkillResponse AddSkill(AddSkillRequest request);
    }
}
