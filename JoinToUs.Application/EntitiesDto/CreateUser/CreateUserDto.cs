using JoinToUs.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToUs.Application.EntitiesDto.CreateUser
{
    public class CreateUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<Passwords> PasswordHash { get; set; } = new List<Passwords>();

    }
}
