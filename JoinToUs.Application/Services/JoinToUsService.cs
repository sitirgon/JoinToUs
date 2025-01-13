using AutoMapper;
using JoinToUs.Application.EntitiesDto.CreateUser;
using JoinToUs.Domain.Entities.User;
using JoinToUs.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToUs.Application.Services
{
    public class JoinToUsService: IJoinToUsService
    {
        private readonly IJoinToUsRepository joinToUsRepository;
        private readonly IMapper mapper;

        public JoinToUsService(IJoinToUsRepository joinToUsRepository, IMapper mapper)
        {
            this.joinToUsRepository = joinToUsRepository;
            this.mapper = mapper;
        }

        public async Task Create(CreateUserDto createUserDto)
        {
            var user = mapper.Map<Users>(createUserDto);

            //user.PasswordHash = new List<Passwords> { passwords };

            await joinToUsRepository.Create(user);
        }
    }
}
