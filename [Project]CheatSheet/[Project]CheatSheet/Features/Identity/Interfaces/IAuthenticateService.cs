namespace _Project_CheatSheet.Features.Identity.Interfaces
{
    using _Project_CheatSheet.Features.Identity.Models;
    using System.IdentityModel.Tokens.Jwt;

    public interface IAuthenticateService
    {

        Task<string> AuthenticateLogin(LoginModel loginModel);

        Task<string> AuthenticateRegsiter(RegisterModel registerModel);

    }
}
