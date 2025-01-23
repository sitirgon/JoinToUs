using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoinToUs.Domain.Entities.User;

namespace JoinToUs.Domain.Interfaces
{
    public interface IJoinToUsRepository
    {
        Task Create(User user);
        Task<User?> GetUserByUserName(string username);
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetUserByEmail(string email);
        Task Commit();
    }
}
