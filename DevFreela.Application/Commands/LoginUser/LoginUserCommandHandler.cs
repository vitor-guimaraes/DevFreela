using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }
    
        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            //Algoritmo pra criar hash da senha
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            //Buscar usuário no banco de dados usuário com senha com hash correspondente 
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            if (user == null)
                return null;

            var token = _authService.GenereateJwtToken(user.Email, user.Role);

            var loginUserViewModel = new LoginUserViewModel(user.Email, token);

            return loginUserViewModel;

        }

    }
}
