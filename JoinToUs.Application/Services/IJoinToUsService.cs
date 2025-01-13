using JoinToUs.Application.EntitiesDto.CreateUser;
using JoinToUs.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToUs.Application.Services
{
    public interface IJoinToUsService
    {
        Task Create(CreateUserDto createUserDto);
        Task<IEnumerable<CreateUserDto>> GetAll();
    }
}
