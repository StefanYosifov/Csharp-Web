namespace _Project_CheatSheet.Features.Identity.Interfaces
{
    using Models;

    public interface IAuthenticateService
    {
        Task<string> AuthenticateLogin(LoginModel loginModel);

        Task<string> AuthenticateRegister(RegisterModel registerModel);
    }
}