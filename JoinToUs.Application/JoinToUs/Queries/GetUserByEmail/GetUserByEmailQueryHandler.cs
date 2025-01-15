using AutoMapper;
using JoinToUs.Application.EntitiesDto.CreateUser;
using JoinToUs.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToUs.Application.JoinToUs.Queries.GetUserByEmail
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, CreateUserDto>
    {
        private readonly IJoinToUsRepository joinToUsRepository;
        private readonly IMapper mapper;
        public GetUserByEmailQueryHandler(IJoinToUsRepository joinToUsRepository, IMapper mapper)
        {
            this.joinToUsRepository = joinToUsRepository;
            this.mapper = mapper;
        }
        public async Task<CreateUserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var join = await joinToUsRepository.GetUserByEmail(request.Email);
            var dto = mapper.Map<CreateUserDto>(join);

            return dto;
        }
    }
}
