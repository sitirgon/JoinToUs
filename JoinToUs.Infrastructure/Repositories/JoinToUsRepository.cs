using JoinToUs.Domain.Entities.User;
using JoinToUs.Domain.Interfaces;
using JoinToUs.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToUs.Infrastructure.Repositories
{
    public class JoinToUsRepository: IJoinToUsRepository
    {
        private readonly JoinToUsDbContext ctx;
        
        public JoinToUsRepository(JoinToUsDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task Create(User user)
        {
            ctx.Users.Add(user);
            await ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
            => (IEnumerable<User>)await (from user in ctx.Users
                      join password in ctx.Passwords on user.Id equals password.UserId
                      select new
                      {
                          user.UserName,
                          user.Email,
                          user.PhoneNumber,
                          password.PasswordHash
                      }).ToListAsync();

        public Task<User?> GetUserByUserName(string username)
            => ctx.Users.FirstOrDefaultAsync(c => c.UserName.ToLower() == username.ToLower());
    }
}
