﻿namespace _Project_CheatSheet.Features.Identity.Services;

using _Project_CheatSheet.Common.UserService.Interfaces;
using AutoMapper;
using Infrastructure.Data.Models;
using Infrastructure.Data.Models.Enums;
using Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class AuthenticateService : IAuthenticateService
{
    private const int IdentityTokenHoursExpiration = 48;

    private readonly IConfiguration configuration;
    private readonly IMapper mapper;
    private readonly ICurrentUser userService;
    private readonly SignInManager<User> signInManager;
    private readonly UserManager<User> userManager;

    public AuthenticateService(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IConfiguration configuration,
        IMapper mapper,
        ICurrentUser userService)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.configuration = configuration;
        this.mapper = mapper;
        this.userService = userService;
    }

    public async Task<Response> AuthenticateLogin(LoginModel loginModel)
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
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.NameIdentifier, user.Id),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        foreach (var userRole in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }

        var token = GetToken(authClaims);

        var response = await GetResponse(token, user);
        return response;
    }

    public async Task<Response> AuthenticateRegister(RegisterModel registerModel)
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

        var user = mapper.Map<User>(registerModel);
        var result = await userManager.CreateAsync(user, registerModel.Password);

        if (!result.Succeeded)
        {
            return null;
        }

        await userManager.AddToRoleAsync(user, ApplicationRolesEnum.User.ToString());

        var authClaims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.NameIdentifier, user.Id),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(ClaimTypes.Role, ApplicationRolesEnum.User.ToString())
        };

        var token = GetToken(authClaims);
        var response = await GetResponse(token, user);
        return response;
    }

    private async Task<Response> GetResponse(JwtSecurityToken token, User user)
    {
        var response = new Response();
        response.accessToken = new JwtSecurityTokenHandler().WriteToken(token);
        response.Roles = await userManager.GetRolesAsync(user);
        response.UserId = userService.GetUserId();
        return response;
    }

    private JwtSecurityToken GetToken(List<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

        var token = new JwtSecurityToken(
            configuration["JWT:ValidIssuer"],
            configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(IdentityTokenHoursExpiration),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return token;
    }
}