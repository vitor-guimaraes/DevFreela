using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullname, int id, bool active)
        {
            Fullname = fullname;
            Id = id;
            Active = active;
            CreatedAt = DateTime.Now;
        }

        public User(string fullname, 
                    string email,
                    string password,
                    DateTime birthDate, 
                    bool active)
        {            
            Fullname = fullname;
            Email = email;
            Password = password;
            BirthDate = birthDate;
            Active = true;

            CreatedAt = DateTime.Now;
            Skills = new List<UserSkill>();
            OwnedProjects = new List<Project>();
            FreelanceProjects = new List<Project>();
        }

        public string Fullname { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; set; }
        public List<UserSkill> Skills { get; private set; }
        public List<Project> OwnedProjects { get; private set; }
        public List<Project> FreelanceProjects { get; private set; }
        public List<ProjectComment> Comments { get; private set; }

        public void Remove()
        {
            if(Active == true)
            {
                Active = false;
            }
        }
        public void Update
            (int id, string fullname, string email, string password, 
            List<Project> ownedProjects, List<UserSkill> skills, bool active)
        {
            Id = id;
            Fullname = fullname;
            Email = email;
            Password = password;
            OwnedProjects = ownedProjects;
            Skills = skills;
            Active = active;
        }
    }
}
