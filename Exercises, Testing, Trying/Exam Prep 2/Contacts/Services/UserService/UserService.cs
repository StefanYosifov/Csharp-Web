namespace Contacts.Services.Users
{
    using System.Security.Claims;

    public class UserService : IUserService
    {
        private readonly ClaimsPrincipal _user;

        public UserService(
            IHttpContextAccessor httpContext)
        {
            _user = httpContext.HttpContext!.User;
        }

        public string GetUserId()
        {
            return _user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}