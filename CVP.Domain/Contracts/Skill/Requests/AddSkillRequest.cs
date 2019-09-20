using System;
using System.Collections.Generic;
using System.Text;

namespace CVP.Domain.Contracts.Skill.Requests
{
    public class AddSkillRequest : RequestBase
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }
}
