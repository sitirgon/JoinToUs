using JoinToUs.Application.EntitiesDto;
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
        Task Create(UsersDto user, PasswordDto passwords);
    }
}
