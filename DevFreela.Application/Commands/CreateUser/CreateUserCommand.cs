using DevFreela.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<User>
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }

    }
}
