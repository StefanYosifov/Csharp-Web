using _Project_CheatSheet.Features.Identity.Interfaces;
using _Project_CheatSheet.Features.Identity.Models;
using _Project_CheatSheet.GlobalConstants.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _Project_CheatSheet.Features.Identity
{
    [AllowAnonymous]
    [Route("/authenticate")]
    public class AuthenticateController : ApiController
    {
        private readonly IAuthenticateService service;

        public AuthenticateController(IAuthenticateService service)
        {
            this.service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var authenticateResult = await service.AuthenticateLogin(loginModel);
            if (string.IsNullOrWhiteSpace(authenticateResult))
            {
                return BadRequest(UserIdentityMessages.OnFailedRegister);
            }

            return Ok(authenticateResult);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            var authenticateResult = await service.AuthenticateRegister(registerModel);
            if (string.IsNullOrWhiteSpace(authenticateResult))
            {
                return BadRequest(UserIdentityMessages.OnFailedRegister);
            }

            return Ok(authenticateResult);
        }
    }
}