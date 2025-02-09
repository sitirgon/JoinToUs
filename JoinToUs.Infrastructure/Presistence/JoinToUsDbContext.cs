﻿using JoinToUs.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoinToUs.Infrastructure.Presistence
{
    public class JoinToUsDbContext: DbContext
    {
        public JoinToUsDbContext(DbContextOptions<JoinToUsDbContext> options): base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Password> Passwords { get; set; }
    }
}
