﻿using DevFreela.API.Models;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _usersService.GetAllUsers();

            List<UsersViewModel> userList = new List<UsersViewModel>(users);

            return Ok(userList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _usersService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user); 
        }

<<<<<<< HEAD
        [HttpGet]
        public IActionResult Get()
        {
            List<UsersViewModel> UserList = _usersService.GetAllUsers();
            return Ok(UserList);
        }
=======
>>>>>>> EFCore

        [HttpPost]
        public IActionResult Post([FromBody] CreateUsersInputModel createUserModel)
        {
            var id = _usersService.Create(createUserModel);

            return CreatedAtAction(nameof(GetById), 
                                    new { id = id }, 
                                    createUserModel);
        }

        [HttpPut("{id}/login")]
        public IActionResult UpdateUser(int id, [FromBody] UpdateUsersInputModel inputModel)
        {
            inputModel.Id = id;

            _usersService.Update(inputModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _usersService.Delete(id);

            return NoContent();
        }
    }
}
