using DevFreela.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public UpdateUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<Project> OwnedProjects { get; set; }
        public List<UserSkill> Skills { get; set; }
        public bool Active { get; set; }
    }
}
