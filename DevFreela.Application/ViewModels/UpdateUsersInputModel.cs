using DevFreela.Core.Entities;
using System.Collections.Generic;

namespace DevFreela.Application.ViewModels
{
    public class UpdateUsersInputModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<Project> OwnedProjects { get; set; }
        public List<UserSkill> Skills { get; set; }
        public bool Active { get; set; }
    }
}
