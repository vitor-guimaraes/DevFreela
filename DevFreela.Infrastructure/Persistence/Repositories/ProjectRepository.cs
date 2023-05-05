﻿using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public ProjectRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Project>> GetAllProjects()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetProjectById(int id)
        {
            return await _dbContext.Projects.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddProjectAsync(Project project)
        {

            await _dbContext.Projects.AddAsync(project);

            await _dbContext.SaveChangesAsync();
        }
    }
}
