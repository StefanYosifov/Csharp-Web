namespace Homies.Services.UserService
{
    using Microsoft.AspNetCore.Identity;

    public interface IUserService
    {
        public string GetUserId();

        public string GetUserName();
    }
}