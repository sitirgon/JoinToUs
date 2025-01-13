using AutoMapper;
using JoinToUs.Application.EntitiesDto.CreateUser;
using JoinToUs.Domain.Entities.User;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToUs.Application.Mappings
{
    public class CreateUserProfile: Profile
    {
        public CreateUserProfile()
        {
            CreateMap<CreateUserDto, User>()
                .ForMember(e => e.PasswordHash, opt => opt.MapFrom(src => new List<Password>
                { new Password() {PasswordHash = src.PasswordHash } }));

            CreateMap<User, CreateUserDto>()
                .ForMember(e => e.PasswordHash, opt => opt.MapFrom(src => src.PasswordHash.First().PasswordHash));
        }
    }
}
