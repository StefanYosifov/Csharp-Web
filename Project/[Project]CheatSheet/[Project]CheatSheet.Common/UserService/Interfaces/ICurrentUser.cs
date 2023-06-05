namespace _Project_CheatSheet.Common.CurrentUser.Interfaces
{
    using Infrastructure.Data.Models;

    public interface ICurrentUser
    {
        public Task<User> GetUser();

        public string GetUserId();

        public string GetUserName();
    }
}