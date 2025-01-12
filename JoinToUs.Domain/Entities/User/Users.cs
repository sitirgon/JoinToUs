using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToUs.Domain.Entities.User
{
    public class Users : BaseEntity
    {
        public Users() 
        {
            PasswordHash = new List<Passwords>();
        }
        public required string UserName { get; set; } 
        public required string Email { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<Passwords> PasswordHash { get; set; }
    }
}
