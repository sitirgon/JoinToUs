using JoinToUs.Application.EntitiesDto.CreateUser;
using JoinToUs.Domain.Entities.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToUs.Application.JoinToUs.Queries.GetAllUsers
{
    public class GetAllUsersQuery: IRequest<IEnumerable<CreateUserDto>>
    {

    }
}
