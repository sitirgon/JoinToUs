using AutoMapper;
using JoinToUs.Application.EntitiesDto;
using JoinToUs.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToUs.Application.Mappings
{
    public class UsersProfile: Profile
    {
       public UsersProfile() 
        {
            CreateMap<UsersDto, Users>();
        }
    }
}
