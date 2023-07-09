﻿namespace _Project_CheatSheet.Features.Identity
{
    using Common.Filters;
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
        [ActionFilter("",UserIdentityMessages.OnFailedLogin)]
        public async Task<Response> Login(LoginModel loginModel)
            => await service.AuthenticateLogin(loginModel);
        


        [HttpPost("register")]
        public async Task<Response> Register(RegisterModel registerModel)
            => await service.AuthenticateRegister(registerModel);
        
    }
}