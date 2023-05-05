using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository _projectRepository;
        public CreateProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project
                        (request.Title,
                        request.Description, request.IdClient,
                        request.IdFreelancer, request.TotalCost,
                        request.StartedAt, request.FinishedAt,
                        request.ClientFullName, request.FreelancerFullname
                        );

            await _projectRepository.AddProjectAsync(project);

            return project.Id;

            throw new NotImplementedException();
        }
    }
}
