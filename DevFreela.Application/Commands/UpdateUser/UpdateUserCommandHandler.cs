using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.UpdateUser
{
    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;
        public UpdateUserCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == request.Id);

            user.Update(request.Id, request.FullName,
                        request.Email, request.OwnedProjects,
                        request.Skills, request.Active);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;

            throw new NotImplementedException();
        }
    }
}
