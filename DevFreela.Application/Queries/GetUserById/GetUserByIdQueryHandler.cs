using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UsersDetailsViewModel>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UsersDetailsViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.Id);

            if (user == null)
                return null;

            var usersDetailsViewModel = new UsersDetailsViewModel(
                                        user.Id,
                                        user.FullName,
                                        user.Email,
                                        user.OwnedProjects,
                                        user.Skills,
                                        user.Active
                                        );

            return usersDetailsViewModel;

            throw new NotImplementedException();
        }
    }
}
