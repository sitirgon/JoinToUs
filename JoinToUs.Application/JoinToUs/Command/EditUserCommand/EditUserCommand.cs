using JoinToUs.Application.EntitiesDto.CreateUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToUs.Application.JoinToUs.Command.EditUserCommand
{
    public class EditUserCommand: CreateUserDto, IRequest
    {
    }
}
