using Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Data
{
    public class LbDbContext : DbContext
    {
        public LbDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Walk>  Walks { get; set; }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }
    }
}
