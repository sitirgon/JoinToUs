using JoinToUs.Application.EntitiesDto.CreateUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToUs.Application.JoinToUs.Queries.GetUserByEmail
{
    public class GetUserByEmailQuery: IRequest<CreateUserDto>
    {
        public string Email { get; set; }
        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
