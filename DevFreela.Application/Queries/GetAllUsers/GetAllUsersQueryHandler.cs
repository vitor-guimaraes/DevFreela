using DevFreela.Application.Queries.GetUser;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UsersViewModel>>
    {
        private readonly IUserRepository _userRepository;
        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UsersViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        //public Task<List<UsersViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUsers();

            var usersViewModel = users.Select
                                           (u => new UsersViewModel
                                           (u.Fullname,
                                            u.Id,
                                            u.Active)
                                           ).ToList();

            return usersViewModel;

            //MOVIDO PARA USERREPOSITORY
            //var users = _dbContext.Users;

            //var usersViewModel = users.Select(u => new UsersViewModel
            //                                                    (u.Fullname,
            //                                                     u.Id,
            //                                                     u.Active))
            //                                                    .ToListAsync();

            //return usersViewModel;

            //throw new NotImplementedException();
        }
    }
}
