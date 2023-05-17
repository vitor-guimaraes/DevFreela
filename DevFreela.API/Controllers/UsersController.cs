using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.DeleteUser;
using DevFreela.Application.Commands.UpdateUser;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetUser;
using DevFreela.Application.Queries.GetUserById;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        //public UsersController(IUsersService usersService)
        //{
        //    _usersService = usersService;
        //}

        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var getAllUsers = new GetAllUsersQuery();

            var users = await _mediator.Send(getAllUsers);

            return Ok(users);
        }
        //public IActionResult Get()
        //{
        //    var users = _usersService.GetAllUsers();

        //    List<UsersViewModel> userList = new List<UsersViewModel>(users);

        //    return Ok(userList);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var getUserById = new GetUserByIdQuery(id);

            var users = await _mediator.Send(getUserById);

            return Ok(users);
        }
        //public IActionResult GetById(int id)
        //{
        //    var user = _usersService.GetById(id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(user); 
        //}

        [HttpPost]
        public async Task <IActionResult>CreateUser([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetUserById), new { id = id }, command);
        }
        //public IActionResult Post([FromBody] CreateUsersInputModel createUserModel)
        //{
        //    var id = _usersService.Create(createUserModel);

        //    return CreatedAtAction(nameof(GetById), 
        //                            new { id = id }, 
        //                            createUserModel);
        //}

        [HttpPut("{id}/login")]
        public async Task<IActionResult>UpdateUser(int id, [FromBody] UpdateUserCommand command)
        {
            command.Id = id;

            await _mediator.Send(command);

            return NoContent();
        }
        //public IActionResult UpdateUser(int id, [FromBody] UpdateUsersInputModel inputModel)
        //{
        //    inputModel.Id = id;

        //    _usersService.Update(inputModel);

        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
        //public IActionResult Delete(int id)
        //{
        //    _usersService.Delete(id);

        //    return NoContent();
        //}
    }
}
