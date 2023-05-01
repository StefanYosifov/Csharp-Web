namespace _Project_CheatSheet.Features.Identity.Services
{
    using _Project_CheatSheet.Data.Models;
    using _Project_CheatSheet.Features.Identity.Interfaces;
    using _Project_CheatSheet.Features.Identity.Models;
    using _Project_CheatSheet.Controllers.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;

    public class AuthenticateService : IAuthenticateService
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public AuthenticateService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IConfiguration configuration,
            IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        public async Task<string> AuthenticateLogin(LoginModel loginModel)
        {
            var user = await userManager.FindByNameAsync(loginModel.Username);
            if (user == null)
            {
                return null;
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, loginModel.Password, false);
            if (!result.Succeeded)
            {
                return null;
            }

            var userRoles = await userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            var token = GetToken(authClaims);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> AuthenticateRegsiter(RegisterModel registerModel)
        {
            var userNameExists = await userManager.FindByNameAsync(registerModel.UserName);
            if (userNameExists != null)
            {
                return null;
            }
            var emailExists = await userManager.FindByEmailAsync(registerModel.Email);
            if (emailExists != null)
            {
                return null;
            }

            User user = mapper.Map<User>(registerModel);
            var result = await userManager.CreateAsync(user, registerModel.Password);

            if (!result.Succeeded)
            {
                return null;
            }
            var authClaims = new List<Claim>
                {
                   new Claim(ClaimTypes.Name, user.UserName),
                   new Claim(ClaimTypes.NameIdentifier,user.Id),
                   new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                   new Claim(ClaimTypes.Role, "User")
                };

            var token = GetToken(authClaims);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(IdentityConstantsModels.IdentityTokenHoursExpiration),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
