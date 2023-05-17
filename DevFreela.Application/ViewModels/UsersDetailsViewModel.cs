using DevFreela.Core.Entities;
using System.Collections.Generic;

namespace DevFreela.Application.ViewModels
{
    public class UsersDetailsViewModel
    {
        public UsersDetailsViewModel(int id, string fullname, 
                                    string email, string password, 
                                    List<Project> ownedProjects, 
                                    List<UserSkill> skills, bool active)
        {
            Id = id;
            Fullname = fullname;
            Email = email;
            Password = password;
            OwnedProjects = ownedProjects;
            Skills = skills;
            Active = active;
        }

        public int Id { get; private set;}
        public string Fullname { get; private set; }
        public string Email { get; private set;}
        public string Password { get; private set;}
        public List<Project> OwnedProjects { get; private set; }
        public List<UserSkill> Skills { get; private set;}
        public bool Active { get; private set; }
    }
}
