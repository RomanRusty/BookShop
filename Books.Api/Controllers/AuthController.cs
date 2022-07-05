using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Books.Contracts;
using Books.Contracts.Exceptions;
using Books.Contracts.Responses;
using Books.Core.Entities.Identity;
using Books.Core.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Books.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
                return Unauthorized();
            return Ok(new AuthSuccessResponse(await GenerateTokenAsync(user.UserName)));
        }

        [HttpPost]
        [Route("register-reader")]
        public async Task<IActionResult> RegisterReader([FromBody] RegistrationDto registrationDto)
        {
            var userExists = await _userManager.FindByEmailAsync(registrationDto.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            var user = new Reader()
            {
                Email = registrationDto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registrationDto.Email
            };
            var result = await _userManager.CreateAsync(user, registrationDto.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError);

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            
            return Ok();
        }
        [HttpPost]
        [Route("register-author")]
        public async Task<IActionResult> RegisterAuthor([FromBody] RegistrationDto registrationDto)
        {
            var userExists = await _userManager.FindByEmailAsync(registrationDto.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            var user = new Author()
            {
                Email = registrationDto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registrationDto.Email
            };
            var result = await _userManager.CreateAsync(user, registrationDto.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError);

            if (await _roleManager.RoleExistsAsync(UserRoles.Author))
            
                await _userManager.AddToRoleAsync(user, UserRoles.Author);
            
            return Ok();
        }
        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegistrationDto registrationDto)
        {
            var userExists = await _userManager.FindByEmailAsync(registrationDto.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            var user = new Admin()
            {
                Email = registrationDto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registrationDto.Email
            };
            var result = await _userManager.CreateAsync(user, registrationDto.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError);

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);

            return Ok();
        }
        private async Task<string> GenerateTokenAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                throw new NotFoundException($"User with {userName} username was not found");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtTokenSection = _configuration.GetSection("JwtToken");

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Name, user.UserName),
            };

            foreach (var role in await _userManager.GetRolesAsync(user))
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var token = GetJwtToken(
                user.Id.ToString(),
                jwtTokenSection["Secret"],
                jwtTokenSection["ValidIssuer"],
                jwtTokenSection["ValidAudience"],
                TimeSpan.FromMinutes(Convert.ToInt32(jwtTokenSection["TokenTimeoutMinutes"])),
                claims.ToArray());
            return tokenHandler.WriteToken(token);
        }
        public static JwtSecurityToken GetJwtToken(string username, string signingKey,
            string issuer, string audience, TimeSpan expiration, Claim[] additionalClaims)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,username),
                // this guarantees the token is unique
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var claimList = new List<Claim>(claims);
            claimList.AddRange(additionalClaims);
            claims = claimList.ToArray();


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                expires: DateTime.UtcNow.Add(expiration),
                claims: claims,
                signingCredentials: credentials
            );
        }
    }
}
