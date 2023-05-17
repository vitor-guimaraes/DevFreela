using DevFreela.Application.Commands.CreateUser;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Text.RegularExpressions;

namespace DevFreela.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("Email inválido");

            RuleFor(p => p.Password)
                .Must(ValidPassword)
                .WithMessage("8 caracteres, min mai, num, alfa num");
        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }
    }
}
