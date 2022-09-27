using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevFreela.API.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;
        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        // GET: api/<SkillsController>
        [HttpGet]
        public IActionResult GetSkills()
        {
            var skills = _skillService.GetAll();

            return Ok(skills);
        }

    }
}
