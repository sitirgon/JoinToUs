using AutoMapper;
using JoinToUs.Application.EntitiesDto.CreateUser;
using JoinToUs.Domain.Entities.User;
using JoinToUs.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToUs.Application.JoinToUs.Command.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IMapper mapper;
        private readonly IJoinToUsRepository joinToUsRepository;

        public CreateUserCommandHandler(IJoinToUsRepository joinToUsRepository, IMapper mapper)
        {
            this.joinToUsRepository = joinToUsRepository;
            this.mapper = mapper;
        }
        public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(request);

            await joinToUsRepository.Create(user);

            return;
        }
    }
}
