using DevFreela.Application.ViewModels;
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
        private readonly DevFreelaDbContext _dbContext;
        public GetUserByIdQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UsersDetailsViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == request.Id);

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
