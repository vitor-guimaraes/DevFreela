using DevFreela.Core.Entities;
using System.Collections.Generic;

namespace DevFreela.Application.ViewModels
{
    public class UsersDetailsViewModel
    {
        public UsersDetailsViewModel(int id, string fullName, string email, List<Project> ownedProjects, List<UserSkill> skills)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            OwnedProjects = ownedProjects;
            Skills = skills;
        }

        public int Id { get; private set;}
        public string FullName { get; private set; }
        public string Email { get; private set;}
        public List<Project> OwnedProjects { get; private set; }
        public List<UserSkill> Skills { get; private set;}
    }
}
