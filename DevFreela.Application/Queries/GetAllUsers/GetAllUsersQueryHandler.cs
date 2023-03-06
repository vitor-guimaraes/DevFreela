using DevFreela.Application.Queries.GetUser;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
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
    internal class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UsersViewModel>>
    {
        private readonly DevFreelaDbContext _dbContext;
        public GetAllUsersQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<UsersViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _dbContext.Users;

            var usersViewModel = users.Select(u => new UsersViewModel
                                                                (u.FullName,
                                                                 u.Id,
                                                                 u.Active))
                                                                .ToListAsync();

            return usersViewModel;

            throw new NotImplementedException();
        }
    }
}
