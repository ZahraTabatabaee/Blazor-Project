using Microsoft.EntityFrameworkCore;
using P10.Server.Controllers;
using P10.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P10.Server.DB
{
    public class KalaDBContext : DbContext
    {
        public KalaDBContext(DbContextOptions<KalaDBContext> options)
            : base(options)
        {}
        public DbSet<kala> Kalas {get; set;}
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}