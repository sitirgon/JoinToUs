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
            CreateMap<CreateUserDto, Users>()
                .ForMember(e => e.PasswordHash, opt => opt.MapFrom(src => new Pas
                  }));
        }
    }
}
