using Microsoft.EntityFrameworkCore;
using P10.Server.Controllers;
using P10.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P10.Server.DB
{
    public class UserDBContext : DbContext
    {
        public UserDBContext(DbContextOptions<UserDBContext> options)
            : base(options)
        {}
        public DbSet<User> Users {get; set;}
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}