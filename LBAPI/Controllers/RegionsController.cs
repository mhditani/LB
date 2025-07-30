using AutoMapper;
using Entities.Data;
using Entities.Domain;
using Entities.DTO_S;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Services.Repositories;
using System.Text.Json;

namespace LBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly LbDbContext db;
        private readonly IRegionRepo repo;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public RegionsController(LbDbContext db, IRegionRepo repo, IMapper mapper, ILogger<RegionsController> logger)
        {
            this.db = db;
            this.repo = repo;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAllRegions()
        {
            try
            {
                throw new Exception("This is a custom exception");

                // Get data from DB
                var regionsDomain = await repo.GetAllAsync();
                // Map Domain model to DTO
                var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain);

                //return DTO back to client

                logger.LogInformation($"Finished get all regions request with data: {JsonSerializer.Serialize(regionsDomain)}");

                return Ok(regionsDto);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw;
            }

         
        }


        [HttpGet("{id:Guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
           var regionDomain = await repo.GetByIdAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }

            // Map RegionDomain to DTO
            // return DTO to client
            return Ok(mapper.Map<RegionDto>(regionDomain));
        }


        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateRegion([FromBody]CreateRegionDto createRegionDto)
        {
            if (ModelState.IsValid)
            {
                // Map Dto to domain model
                var regionDomain = mapper.Map<Region>(createRegionDto);

                // use domain model to create Region
                regionDomain = await repo.CreateAsync(regionDomain);

                // Map domain back to DTO
                var regionDto = mapper.Map<RegionDto>(regionDomain);

                return CreatedAtAction(nameof(GetById), new { regionDomain.Id }, regionDto);
            }
            return BadRequest(ModelState);
           
        }


        [HttpPut("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionDto updateRegionDto)
        {
            if (ModelState.IsValid)
            {
                // Map DTO to domain model
                var regionDomain = mapper.Map<Region>(updateRegionDto);

                // Call repo to update
                var updatedRegion = await repo.UpdateAsync(id, regionDomain);

                // Check if region exists
                if (updatedRegion == null)
                {
                    return NotFound();
                }

                // Map domain model back to DTO
                var regionDto = mapper.Map<RegionDto>(regionDomain);

                return Ok(regionDto);
            }
            return BadRequest(ModelState);
          
        }



        [HttpDelete("{id:Guid}")]
        [Authorize(Roles = "Writer")]   
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
           var regionDomain = await repo.DeleteAsync(id);
            if (regionDomain == null)
            {
                return NotFound();
            }


            // map domain to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomain);
            return Ok(regionDto);
        }
    }
}
