using System;
using System.Collections.Generic;
using System.Text;

namespace CVP.Domain.Dtos.Skill
{
    public class UpdateSkillDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }
}
