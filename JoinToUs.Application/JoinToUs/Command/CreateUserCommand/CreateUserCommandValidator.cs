using FluentValidation;
using JoinToUs.Application.EntitiesDto.CreateUser;
using JoinToUs.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToUs.Application.JoinToUs.Command.CreateUserCommand
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator(IJoinToUsRepository repo)
        {
            RuleFor(c => c.UserName)
                .NotEmpty()
                .MinimumLength(2).WithMessage("Username should have atlest 2 characters")
                .MaximumLength(128)
                .Custom((value, context) =>
                {
                    var existingUserName = repo.GetUserByUserName(value).Result;

                    if (existingUserName != null)
                    {
                        context.AddFailure($"{value} is not unique and already existing in databse");
                    }
                });

            RuleFor(c => c.Email)
                .NotEmpty()
                .MinimumLength(6).WithMessage("Email should have correct format")
                .MaximumLength(128);

            RuleFor(c => c.PhoneNumber)
                .MaximumLength(13);

            RuleFor(c => c.PasswordHash)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(128);
        }
    }
}
