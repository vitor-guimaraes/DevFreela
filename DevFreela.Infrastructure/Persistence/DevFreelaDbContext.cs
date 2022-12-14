using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Projeto ASPNET Core 1", "Descricao Projeto 1", 1, 1, 10000),
                new Project("Projeto ASPNET Core 2", "Descricao Projeto 2", 1, 1, 20000),
                new Project("Projeto ASPNET Core 3", "Descricao Projeto 3", 1, 1, 30000)
            };

            Users = new List<User>
            {
                new User("Jarlão", "Jarlão@jarlos.com.br", new DateTime(1896,6,6)),
                new User("Treco", "Treco@jarlos.com.br", new DateTime(1972,5,7)),
                new User("Elvis", "Elvis@jarlos.com.br", new DateTime(1935,1,8))
            };

            Skills = new List<Skill>
            {
                new Skill(".NET Core"),
                new Skill("C#"),
                new Skill("SQL")
            };
        }
        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }
    }
}
