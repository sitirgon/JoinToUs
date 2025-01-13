using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToUs.Domain.Entities.User
{
    public class Password: BaseEntity
    {
        public required string PasswordHash { get; set; }
        public string Salt { get; set; } = Path.GetRandomFileName().Replace(".", "");
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
