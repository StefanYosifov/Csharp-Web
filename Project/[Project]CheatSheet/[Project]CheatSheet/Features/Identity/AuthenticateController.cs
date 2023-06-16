namespace _Project_CheatSheet.Features.Identity
{
    using Common.GlobalConstants.User;
    using Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;

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