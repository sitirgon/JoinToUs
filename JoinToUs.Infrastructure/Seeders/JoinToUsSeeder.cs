using JoinToUs.Domain.Entities.User;
using JoinToUs.Infrastructure.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JoinToUs.Infrastructure.Seeders
{
    public class JoinToUsSeeder
    {
        private readonly JoinToUsDbContext ctx;
        public JoinToUsSeeder(JoinToUsDbContext dbContext)
        {
            ctx = dbContext;
        }

        public async Task Seed()
        {
            if (await ctx.Database.CanConnectAsync())
            {
                if (!ctx.Users.Any())
                {
                    var adminUser = new Users()
                    {
                        UserName = "admin",
                        Email = "admin",
                        IsDeleted = false,
                        CreatedAt = DateTime.Now
                    };
                    var adminPassword = new Passwords()
                    {
                        PasswordHash = "admin",
                        UserId = adminUser.Id
                    };
                    adminUser.PasswordHash = new List<Passwords> { adminPassword };

                    ctx.Users.Add(adminUser);
                    await ctx.SaveChangesAsync();
                }
            }
        }
    }
}
