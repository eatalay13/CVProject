using CVP.Business.Interfaces;
using CVP.Data.Repository.Interfaces;
using CVP.Domain.Contracts.Skill.Requests;
using CVP.Domain.Contracts.Skill.Responses;
using CVP.Domain.Dtos.Skill;

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
    }
}
