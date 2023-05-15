using _Project_CheatSheet.Infrastructure.Data.Models;

namespace _Project_CheatSheet.Common.CurrentUser.Interfaces
{
    public interface ICurrentUser
    {
        public Task<User> GetUser();

        public string GetUserId();

        public string GetUserName();
    }
}