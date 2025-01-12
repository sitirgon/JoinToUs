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
        Task Create(Users user);
    }
}
