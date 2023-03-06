using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;

        public DeleteUserCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = _dbContext.Users.
                        SingleOrDefault(u => u.Id == request.Id);

            user.Remove();

            await _dbContext.SaveChangesAsync();

            return Unit.Value;

            throw new NotImplementedException();
        }
    }

}
