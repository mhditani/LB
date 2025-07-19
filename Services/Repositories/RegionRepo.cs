using Entities.Data;
using Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class RegionRepo : IRegionRepo
    {
        private readonly LbDbContext db;

        public RegionRepo(LbDbContext db)
        {
            this.db = db;
        }

        public async Task<Region> CreateAsync(Region region)
        {
             await db.Regions.AddAsync(region);
            await db.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var existingRegion = await db.Regions.FindAsync(id);
            if (existingRegion == null)
            {
                return null;
            }
            db.Regions.Remove(existingRegion);
            await db.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await db.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
           return await db.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await db.Regions.FirstOrDefaultAsync(y => y.Id == id);
            if (existingRegion == null)
            {
                return null;
            }
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.ImageUrl = region.ImageUrl;

            await db.SaveChangesAsync();
            return existingRegion;
        }
    }
}
