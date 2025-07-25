using Entities.Data;
using Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class WalkRepo : IWalkRepo
    {
        private readonly LbDbContext db;

        public WalkRepo(LbDbContext db)
        {
            this.db = db;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await db.Walks.AddAsync(walk);
            await db.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalk = await db.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk == null)
            {
                return null;
            }
            db.Walks.Remove(existingWalk);
            await db.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<List<Walk>> GetAllAsync(string? filteron = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000)
        {
            var walks =  db.Walks.Include("Difficulty").Include("Region").AsQueryable();

            // Filtering
            if (string.IsNullOrWhiteSpace(filteron) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filteron.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }

            // Sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                }else if(sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }
            }

            // Pagination
            var skipResults =  (pageNumber - 1) * pageSize;

            return await walks.Skip(skipResults).Take(pageSize).ToListAsync();
            //return await db.Walks
            //    .Include("Difficulty")
            //    .Include("Region")
            //    .ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await db.Walks
                .Include("Difficulty")
                .Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);
           

        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await db.Walks
                .FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk == null)
            {
                return null;
            }

            // Validate foreign key references
            //var difficultyExists = await db.Difficulties.AnyAsync(d => d.Id == walk.DifficultyId);
            //var regionExists = await db.Regions.AnyAsync(r => r.Id == walk.RegionId);

            //if (!difficultyExists || !regionExists)
            //{
            //    throw new Exception("Invalid DifficultyId or RegionId.");
            //}


            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;

            await db.SaveChangesAsync();
            return existingWalk;
        }
    }
}
