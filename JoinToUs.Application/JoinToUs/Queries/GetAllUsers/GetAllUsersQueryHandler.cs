using AutoMapper;
using JoinToUs.Application.EntitiesDto.CreateUser;
using JoinToUs.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToUs.Application.JoinToUs.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<CreateUserDto>>
    {
        private readonly IMapper mapper;
        private readonly IJoinToUsRepository joinToUsRepository;

        public GetAllUsersQueryHandler(IJoinToUsRepository joinToUsRepository, IMapper mapper)
        {
            this.joinToUsRepository = joinToUsRepository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<CreateUserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await joinToUsRepository.GetAll();
            var dtos = mapper.Map<IEnumerable<CreateUserDto>>(users);

            return dtos;
        }
    }
}
