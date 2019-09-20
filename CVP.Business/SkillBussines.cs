using System.Collections.Generic;
using CVP.Business.Interfaces;
using CVP.Data.Repository.Interfaces;
using CVP.Domain.Contracts.Skill.Requests;
using CVP.Domain.Contracts.Skill.Responses;
using CVP.Domain.Dtos.Skill;
using CVP.Domain.Models;

namespace CVP.Business
{
    public class SkillBussines : ISkillBussines
    {
        private readonly ISkillRepository _skillRepository;

        public SkillBussines(ISkillRepository skillRepository)
        {
            this._skillRepository = skillRepository;
        }
        public AddSkillResponse AddSkill(AddSkillRequest request)
        {
            _skillRepository.AddSkill(new AddSkillDto
            {
                Name = request.Name,
                Score = request.Score
            });

            return new AddSkillResponse();
        }

        public ListSkillResponse GetSkillList()
        {
            var response = new ListSkillResponse
            {
                Skills = _skillRepository.GetSkillList()
            };

            return response;
        }
    }
}
