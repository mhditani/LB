using Entities.DTO_S;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Repositories;

namespace LBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepo tokenRepo;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepo tokenRepo)
        {
            this.userManager = userManager;
            this.tokenRepo = tokenRepo;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            // user manager class that identity provide us
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                // Add Roles to this User
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);
                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registered! Please login.");
                    }
                }
            }

            return BadRequest("Register Failed");
        }



        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
           var User = await userManager.FindByEmailAsync(loginRequestDto.Username);
            if (User != null)
            {
               var checkPassResult = await userManager.CheckPasswordAsync(User, loginRequestDto.Password);
                if (checkPassResult)
                {
                    // Get Roles for this user
                    var roles = await userManager.GetRolesAsync(User);
                    if (roles != null)
                    {
                        // Create Token
                       var jwToken = tokenRepo.CreateJwToken(User, roles.ToList());

                        var response = new LoginResponseDto() 
                        {
                            Jwtoken = jwToken,
                        };

                        return Ok(response);
                    }
                    
                }
            }

            return BadRequest("Wrong Username or Password");
        }
    }
}
