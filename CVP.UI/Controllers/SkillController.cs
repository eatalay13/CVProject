using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CVP.Business.Interfaces;
using CVP.Domain.Contracts.Skill.Requests;
using CVP.Domain.Contracts.Skill.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CVP.UI.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillBussines _skillBussines;

        public SkillController(ISkillBussines skillBussines)
        {
            this._skillBussines = skillBussines;
        }

        [HttpPost]
        public ActionResult<AddSkillResponse> AddSkill([FromBody]AddSkillRequest request)
        {
            var response = _skillBussines.AddSkill(request);

            return response;
        }

        [HttpPost]
        public ActionResult<UpdateSkillResponse> UpdateSkill([FromBody]UpdateSkillRequest request)
        {
            return _skillBussines.UpdateSkill(request);
        }

        [HttpGet]
        public ActionResult<ListSkillResponse> SkillList()
        {
            return _skillBussines.GetSkillList();
        }
    }
}