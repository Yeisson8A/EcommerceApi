using Ecommerce.Application.DTO;
using FluentValidation;

namespace Ecommerce.Application.Validator
{
    public class UsersDtoValidator : AbstractValidator<UsersDto>
    {
        public UsersDtoValidator() 
        {
            RuleFor(r => r.UserName).NotNull().NotEmpty().WithMessage("El valor de 'username' es obligatorio");
            RuleFor(r => r.Password).NotNull().NotEmpty().WithMessage("El valor de 'password' es obligatorio");
        }
    }
}
