using JoinToUs.Domain.Entities.User;
using JoinToUs.Domain.Interfaces;
using JoinToUs.Infrastructure.Presistence;
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

        public async Task Create(Users user)
        {
            ctx.Users.Add(user);
            await ctx.SaveChangesAsync();
        }
    }
}
