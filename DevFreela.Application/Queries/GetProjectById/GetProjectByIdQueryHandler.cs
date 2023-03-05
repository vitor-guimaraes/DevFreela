﻿using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsViewModel>
    {
        private readonly DevFreelaDbContext _dbContext;
        public GetProjectByIdQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ProjectDetailsViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects
            //.Include(p => p.Client)
            //.Include(p => p.Freelancer)
                .SingleOrDefaultAsync(p => p.Id == request.Id);

            if (project == null)
                return null;

            var projectsDetailsViewModel = new ProjectDetailsViewModel(
                                                project.Id,
                                                project.Title,
                                                project.Description,
                                                project.TotalCost,
                                                project.StartedAt,
                                                project.FinishedAt,
                                                project.Status,
                                                project.ClientFullname,
                                                project.FreelancerFullname
                                                );

            return projectsDetailsViewModel;

            //throw new NotImplementedException();
        }
    }
}
