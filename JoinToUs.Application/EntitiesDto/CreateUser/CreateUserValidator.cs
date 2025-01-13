using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToUs.Application.EntitiesDto.CreateUser
{
    public class CreateUserValidator: AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            RuleFor(c => c.UserName)
                .NotEmpty()
                .MaximumLength(2)
                .MaximumLength(128);

            RuleFor(c => c.Email)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(128);

            RuleFor(c => c.PhoneNumber)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(128);

            RuleFor(c => c.PasswordHash)
                .NotEmpty();
        }
    }
}
