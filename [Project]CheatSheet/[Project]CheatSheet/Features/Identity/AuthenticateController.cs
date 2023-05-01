namespace _Project_CheatSheet.Controllers.Identity
{
    using _Project_CheatSheet.Data.Models;
    using _Project_CheatSheet.Features.Identity;
    using _Project_CheatSheet.Features.Identity.Interfaces;
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

        private readonly IAuthenticateService service;

        public AuthenticateController(IAuthenticateService service)
           => this.service = service;

        [AllowAnonymous]
        [HttpPost]
        [Route("/authenticate/login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var authenticateResult = await service.AuthenticateLogin(loginModel);
            if (string.IsNullOrWhiteSpace(authenticateResult))
            {
                return BadRequest(IdentityMessages.onFailedRegister);
            }
            return Ok(authenticateResult);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("/authenticate/register")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {

            var authenticateResult = await service.AuthenticateRegsiter(registerModel);
            if (string.IsNullOrWhiteSpace(authenticateResult))
            {
                return BadRequest(IdentityMessages.onFailedRegister);
            }
            return Ok(authenticateResult);
        }
    }
}
