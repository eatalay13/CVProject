using System;
using System.Collections.Generic;
using System.Text;

namespace CVP.Domain.Contracts.Skill.Requests
{
    public class UpdateSkillRequest : RequestBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }
}
