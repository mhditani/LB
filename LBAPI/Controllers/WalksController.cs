using AutoMapper;
using Entities.Domain;
using Entities.DTO_S;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Repositories;

namespace LBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepo repo;

        public WalksController(IMapper mapper, IWalkRepo repo)
        {
            this.mapper = mapper;
            this.repo = repo;
        }


        [HttpPost]
        public async Task<IActionResult> CreateWalk([FromBody]CreateWalkDto createWalkDto)
        {
            if (ModelState.IsValid)
            {
                // map DTO to Domain 
                var walkDomain = mapper.Map<Walk>(createWalkDto);

                await repo.CreateAsync(walkDomain);


                // Map Domain to DTO
                var walkDto = mapper.Map<WalkDto>(walkDomain);
                return Ok(walkDto);
            }
            return BadRequest(ModelState);
        }


        [HttpGet]
        public async Task<IActionResult> GetWalks()
        {
            var walkDomain = await repo.GetAllAsync();

            // map domain to Dto
            var walkDto = mapper.Map<List<WalkDto>>(walkDomain);
            return Ok(walkDto);
        }


        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomain = await repo.GetByIdAsync(id);
            if (walkDomain == null)
            {
                return NotFound();
            }
            // map Domain to Dto
            return Ok(mapper.Map<WalkDto>(walkDomain));
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid id, [FromBody]UpdateWalkDto updateWalkDto)
        {
            if (ModelState.IsValid)
            {
                // map Dto tp Domain
                var walkDomain = mapper.Map<Walk>(updateWalkDto);
                await repo.UpdateAsync(id, walkDomain);

                if (walkDomain == null)
                {
                    return NotFound();
                }
                // Map Domain to Dto
                return Ok(mapper.Map<WalkDto>(walkDomain));
            }
              return BadRequest(ModelState);
        }


        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkDomain = await repo.DeleteAsync(id);
            if (walkDomain == null)
            {
                return NotFound();
            }
            // Map Domain to Dto
            return Ok(mapper.Map<WalkDto>(walkDomain));
        }
    }
}
