using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly DevFreelaDbContext _dbContext;

        public CreateUserCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

                var user = new User(
                                    request.FullName,
                                    request.Email,
                                    request.BirthDate,
                                    request.Active
                                    );

                await _dbContext.Users.AddAsync(user);

                await _dbContext.SaveChangesAsync();

                return user;

            throw new NotImplementedException();
        }
    }
}
