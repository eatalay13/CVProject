using System;
using System.Collections.Generic;
using System.Text;

namespace CVP.Domain.Contracts.Skill.Responses
{
    public class SkillListResponse : ResponseBase
    {
        public object Skills { get; set; }
    }
}
