using AutoMapper;
using JoinToUs.Domain.Entities.User;
using JoinToUs.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToUs.Application.JoinToUs.Command.EditUserCommand
{
    public class EditUserCommandHandler: IRequestHandler<EditUserCommand>
    {
        private readonly IMapper mapper;
        private readonly IJoinToUsRepository joinToUsRepository;

        public EditUserCommandHandler(IJoinToUsRepository joinToUsRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.joinToUsRepository = joinToUsRepository;
        }
        public async Task Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var entityUser = await joinToUsRepository.GetUserByEmail(request.Email);

            if (entityUser == default)
            {
                throw new InvalidOperationException("Nie ma takiego");
            }

            var entityPassword = entityUser.PasswordHash.FirstOrDefault();

            if (entityPassword.PasswordHash != request.PasswordHash) 
            {
                entityUser.PasswordHash.Clear();
                entityPassword.PasswordHash = request.PasswordHash;
                entityUser.PasswordHash.Add(entityPassword);

            }

            entityUser.Email = request.Email;
            entityUser.PhoneNumber = request.PhoneNumber;
            entityUser.LastUpdatedAt = DateTime.Now;

            await joinToUsRepository.Commit();

            return;
        }
    }
}
