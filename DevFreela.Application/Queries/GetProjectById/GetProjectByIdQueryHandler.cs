using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
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
        private readonly IProjectRepository _projectRepository;
        public GetProjectByIdQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<ProjectDetailsViewModel> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetProjectById(request.Id);

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
