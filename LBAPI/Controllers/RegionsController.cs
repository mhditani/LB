using Entities.Data;
using Entities.Domain;
using Entities.DTO_S;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly LbDbContext db;

        public RegionsController(LbDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            // Get data from DB
            var regionsDomain = await db.Regions.ToListAsync();
            // Map Domain data to DTO
            var regionsDto = new List<RegionDto>();
            foreach (var regionDomain in regionsDomain)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    ImageUrl = regionDomain.ImageUrl
                });
            }
            // return DTO back to client
            return Ok(regionsDto);
        }


        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
           var regionDomain = await db.Regions.FirstOrDefaultAsync(r  => r.Id == id);
            if (regionDomain == null)
            {
                return NotFound();
            }

            // Map RegionDomain to DTO
            var regionDto = new RegionDto() 
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                ImageUrl = regionDomain.ImageUrl
            };

            // return DTO to client
            return Ok(regionDto);
        }


        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody]CreateRegionDto createRegionDto)
        {
            // Map Dto to domain model
            var regionDomain = new Region()
            {
                Code = createRegionDto.Code,
                Name = createRegionDto.Name,
                ImageUrl = createRegionDto.ImageUrl
            };

            // use domain model to create Region
            await db.Regions.AddAsync(regionDomain);
            await db.SaveChangesAsync();

            // Map domain back to DTO
            var regionDto = new RegionDto()
            {
                Id=regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                ImageUrl = regionDomain.ImageUrl
            };

            return CreatedAtAction(nameof(GetById), new {regionDomain.Id}, regionDto);
        }


        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, UpdateRegionDto updateRegionDto)
        {
            // check if region exists
            var regionDomain = await db.Regions.FirstOrDefaultAsync(r => r.Id == id);
            if (regionDomain == null)
            {
                return NotFound();
            }
            // Map Dto to domain model
             regionDomain.Code = updateRegionDto.Code;
            regionDomain.Name = updateRegionDto.Name;
            regionDomain.ImageUrl = updateRegionDto.ImageUrl;

            await db.SaveChangesAsync();

            // convert domain to dto
            var regionDto = new RegionDto()
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                ImageUrl = regionDomain.ImageUrl
            };
            return Ok(regionDto);
        }


        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
           var regionDomain = await db.Regions.FirstOrDefaultAsync(r =>r.Id == id);
            if (regionDomain == null)
            {
                return NotFound();
            }
             db.Remove(regionDomain);
            await db.SaveChangesAsync();

            // map domain to DTO
            var regionDto = new RegionDto()
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                ImageUrl = regionDomain.ImageUrl
            };
            return Ok(regionDto);
        }
    }
}
