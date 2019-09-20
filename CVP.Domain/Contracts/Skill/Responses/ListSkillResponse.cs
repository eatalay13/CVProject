using CVP.Domain.Dtos.Skill;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVP.Domain.Contracts.Skill.Responses
{
    public class ListSkillResponse : ResponseBase
    {
        public List<ListSkillDto> Skills { get; set; }
    }
}
