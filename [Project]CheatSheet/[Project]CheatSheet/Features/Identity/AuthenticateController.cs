namespace _Project_CheatSheet.Controllers.Identity
{
    using _Project_CheatSheet.Data.Models;
    using _Project_CheatSheet.Features.Identity.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;


    [Route("/authenticate")]
    public class AuthenticateController:ApiController
    {

        public IActionResult Index()
        {
            return Ok("Works");
        }

        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;

        public AuthenticateController
            (UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager, 
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("/authenticate/login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var user = await userManager.FindByNameAsync(loginModel.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier,user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return Unauthorized("Error while logging in! Check your credentials");
        }

        [HttpPost]
        [Route("/authenticate/register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {

            var usernameExists = await userManager.FindByNameAsync(registerModel.UserName);
            if (usernameExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Message = "User already exists!" });
            }
            var emailExists = await userManager.FindByEmailAsync(registerModel.Email);
            if (emailExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Message = "Email already exists!" });
            }

            User user = new User()
            {
                Email = registerModel.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerModel.UserName
            };

            var result = await userManager.CreateAsync(user, registerModel.Password);
            if (!result.Succeeded)
            {
                return BadRequest(new Response { Message = "Bad request" });
            }
            return Ok(new Response { Message = "Succesfully logged in!" });
        }


        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(IdentityConstants.IdentityTokenHoursExpiration),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
