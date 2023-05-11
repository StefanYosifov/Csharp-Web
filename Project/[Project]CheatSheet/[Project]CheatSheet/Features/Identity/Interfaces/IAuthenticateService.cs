using _Project_CheatSheet.Features.Identity.Models;

namespace _Project_CheatSheet.Features.Identity.Interfaces
{
    public interface IAuthenticateService
    {
        Task<string> AuthenticateLogin(LoginModel loginModel);

        Task<string> AuthenticateRegister(RegisterModel registerModel);
    }
}