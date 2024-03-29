﻿using DevFreela.Application.Commands.CreateCommand;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    [Authorize]
    public class ProjectsController : ControllerBase
    {
        //private readonly IProjectService _projectService;
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //public ProjectsController(IProjectService projectService)
        //{
        //    _projectService = projectService;            
        //}
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllProjects()
        {
            var getAllProjectsQuery = new GetAllProjectsQuery();

            var projects = await _mediator.Send(getAllProjectsQuery);

            return Ok(projects);
        }
        //public async Task<IActionResult> Get()
        //{
        //    //var projects = _projectService.GetAll();
        //    var command = new GetAllProjectsQuery();

        //    await _mediator.Send(command);

        //    List<ProjectViewModel> projectsList = new List<ProjectViewModel>(projects);

        //    return Ok(projectsList);
        //}

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            //var project = _projectService.GetById(id);
            var query = new GetProjectByIdQuery(id);

            var project = await _mediator.Send(query);

            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            //var id = _projectService.Create(inputModel);
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult>Put(int id, [FromBody] UpdateProjectCommand command)
        {
            if (command.Description.Length > 200)
            {
                return BadRequest();
            }

            command.Id = id;

            //_projectService.Update(inputModel);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        //public IActionResult Delete(int id)
        {
            //_projectService.Delete(id);
            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        [Authorize]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        //public IActionResult PostComment(int id, [FromBody])
        {
            //_projectService.CreateComment(inputModel);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/start")]
        [Authorize]
        public async Task<IActionResult> Start(int id)
        //public IActionResult Start(int id)
        {
            var command = new StartProjectCommand(id);

            //_projectService.Start(id);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}/finish")]
        [Authorize]
        public async Task<IActionResult> Finish(int id, [FromBody] FinishProjectCommand command)
        //public IActionResult Finish(int id)
        {
            command.Id = id;

            var result = await _mediator.Send(command);

            if (!result)
            {
                return BadRequest("sem pagamento");
            }
            //var command = new FinishProjectCommand(id);

            //_projectService.Finish(id);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
