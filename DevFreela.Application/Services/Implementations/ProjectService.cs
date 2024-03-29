﻿using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _dbContext;
        public ProjectService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public int Create(NewProjectInputModel inputModel)
        //{
        //    var project = new Project
        //                (inputModel.Title, 
        //                inputModel.Description, inputModel.IdClient, 
        //                inputModel.IdFreelancer, inputModel.TotalCost,
        //                inputModel.StartedAt, inputModel.FinishedAt,
        //                inputModel.ClientFullName, inputModel.FreelancerFullname
        //                );
            
        //    _dbContext.Projects.Add(project);

        //    _dbContext.SaveChanges();

        //    return project.Id;
        //}

        //public void CreateComment(CreateCommentInputModel inputModel)
        //{
        //    var comment = new ProjectComment(
        //                                    inputModel.Content, 
        //                                    inputModel.IdProject, 
        //                                    inputModel.IdUser);

        //    _dbContext.ProjectComments.Add(comment);

        //    _dbContext.SaveChanges();
        //}

        //public void Delete(int id)
        //{
        //    var project = _dbContext.Projects.
        //                    SingleOrDefault(p => p.Id == id);

        //    project.Cancel();

        //    _dbContext.SaveChanges();
        //}


        //public List<ProjectViewModel> GetAll()
        //{
        //    var projects = _dbContext.Projects;

        //    var projectsViewModel = projects
        //                            .Select(p => new ProjectViewModel
        //                                   (p.Id, 
        //                                    p.Title, 
        //                                    p.CreatedAt,
        //                                    p.Status)).ToList();

        //    return projectsViewModel;
        //}

        //public ProjectDetailsViewModel GetById(int id)
        //{
        //    var project = _dbContext.Projects
        //        //.Include(p => p.Client)
        //        //.Include(p => p.Freelancer)
        //        .SingleOrDefault(p => p.Id == id);

        //    if (project == null)
        //        return null;

        //    var projectsDetailsViewModel = new ProjectDetailsViewModel(
        //                                        project.Id,
        //                                        project.Title,
        //                                        project.Description,
        //                                        project.TotalCost,
        //                                        project.StartedAt,
        //                                        project.FinishedAt,
        //                                        project.ClientFullName,
        //                                        project.FreelancerFullname
        //                                        );

        //    return projectsDetailsViewModel;
        //}

        //public void Finish(int id)
        //{
        //    var project = _dbContext.Projects.
        //                    SingleOrDefault(p => p.Id == id);

        //    project.Finish();

        //    _dbContext.SaveChanges();
        //}

        //public void Start(int id)
        //{
        //    var project = _dbContext.Projects.
        //                    SingleOrDefault(p => p.Id == id);

        //    project.Start();

        //    _dbContext.SaveChanges();
        //}

        //public void Update(UpdateProjectInputModel inputModel)
        //{
        //    var project = _dbContext.Projects.
        //                    SingleOrDefault(p => p.Id == inputModel.Id);
            
        //    project.Update(inputModel.Title, 
        //                    inputModel.Description, 
        //                    inputModel.TotalCost,
        //                    inputModel.Status);

        //    _dbContext.SaveChanges();
        //}
    }
}
