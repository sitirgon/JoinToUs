using JoinToUs.Domain.Entities.User;
using JoinToUs.Domain.Interfaces;
using JoinToUs.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
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

        public async Task Commit()
        {
            await ctx.SaveChangesAsync();
        }
        public async Task Create(User user)
        {
            ctx.Users.Update(user);
            await ctx.SaveChangesAsync();
        }

        public async Task<User?> GetUserByEmail(string email)
            => ctx.Users.FirstOrDefaultAsync(x => x.Email == email).Result;

        public async Task<IEnumerable<User>> GetAll()
           => await (from user in ctx.Users
                              join password in ctx.Passwords on user.Id equals password.UserId
                              select new User
                              {
                                  UserName = user.UserName,
                                  Email = user.Email,
                                  PhoneNumber = user.PhoneNumber != null ? user.PhoneNumber : "Empty",
                                  PasswordHash = new List<Password> { new Password() { PasswordHash = password.PasswordHash } }
                              }  
                              ).ToListAsync();

        public Task<User?> GetUserByUserName(string username)
            => ctx.Users.FirstOrDefaultAsync(c => c.UserName.ToLower() == username.ToLower());
    }
}
