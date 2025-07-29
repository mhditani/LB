using Entities.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Data
{
    public class LbDbContext : IdentityDbContext
    {
        public LbDbContext(DbContextOptions<LbDbContext> options) : base(options)
        {
        }

        public DbSet<Walk>  Walks { get; set; }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Image> Images { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                base.OnModelCreating(modelBuilder);
            // adding roles
            var readerId = "9c19878b-940c-4c05-8663-35d8f9178555";
            var writerId = "00f3d510-437a-40e8-881b-be07cff9527a";

            // Seed Data for difficulties using EF
            // Easy Medium Hard
            var difficulties = new List<Difficulty>()
            {
               new Difficulty()
               {
                    Id = Guid.Parse("6c97267f-ec7d-40c5-b814-51321515c661"),
                    Name = "Easy"
               },
               new Difficulty()
               {
                   Id = Guid.Parse("8efd4ac3-7549-4f14-91b8-c4153e728882"),
                   Name = "Medium"
               },
               new Difficulty()
               {
                   Id = Guid.Parse("e6a6d27d-4e98-41ea-85c5-3f509eb0ed77"),
                   Name = "Hard"
               }
            };


            // Seed difficulties to database 
            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            var regions = new List<Region>
{
    new Region
    {
        Id = Guid.Parse("a1f1c555-1111-4a51-b1a1-000000000001"),
        Code = "BEY",
        Name = "Beirut",
        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/5/53/Beirut_Central_District.jpg"
    },
    new Region
    {
        Id = Guid.Parse("a1f1c555-1111-4a51-b1a1-000000000002"),
        Code = "MLB",
        Name = "Mount Lebanon",
        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/31/Bekish_monastery_001.jpg"
    },
    new Region
    {
        Id = Guid.Parse("a1f1c555-1111-4a51-b1a1-000000000003"),
        Code = "NLB",
        Name = "North Lebanon",
        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/d/d7/Ehden_View.jpg"
    },
    new Region
    {
        Id = Guid.Parse("a1f1c555-1111-4a51-b1a1-000000000004"),
        Code = "AKK",
        Name = "Akkar",
        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/88/Akkar_Lebanon_village_landscape.jpg"
    },
    new Region
    {
        Id = Guid.Parse("a1f1c555-1111-4a51-b1a1-000000000005"),
        Code = "BEK",
        Name = "Bekaa",
        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/4b/Zahle_Bekaa_Valley_Lebanon_2009.jpg"
    },
    new Region
    {
        Id = Guid.Parse("a1f1c555-1111-4a51-b1a1-000000000006"),
        Code = "BHM",
        Name = "Baalbek-Hermel",
        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/3c/Baalbek_Roman_ruins.jpg"
    },
    new Region
    {
        Id = Guid.Parse("a1f1c555-1111-4a51-b1a1-000000000007"),
        Code = "SLB",
        Name = "South Lebanon",
        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/33/Tyre_harbor_south_lebanon_2006.jpg"
    },
    new Region
    {
        Id = Guid.Parse("a1f1c555-1111-4a51-b1a1-000000000008"),
        Code = "NAB",
        Name = "Nabatieh",
        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/f/f3/Nabatieh_Lebanon_view.jpg"
    }
};
            // Seed data for regions
            modelBuilder.Entity<Region>().HasData(regions);

            // seed data for roles
            var roles = new List<IdentityRole>
            {
                
                new IdentityRole()
                {
                    Id = readerId,
                    ConcurrencyStamp = readerId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole()
                {
                    Id = writerId,
                    ConcurrencyStamp = writerId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }

        

       
    }
}
