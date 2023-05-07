﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllProjects();
        Task<Project> GetProjectById(int id);
        Task AddProjectAsync(Project project);
        Task StartProjectAsync(int id);
    }
}
