using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToUs.Domain.Entities.User
{
    public class User : BaseEntity
    {
        public User()
        {
            
        }
        public string UserName { get; set; } 
        public string Email { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<Password> PasswordHash { get; set; }
    }
}
