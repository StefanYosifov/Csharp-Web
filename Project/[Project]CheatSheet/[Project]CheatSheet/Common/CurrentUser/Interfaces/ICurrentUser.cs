namespace _Project_CheatSheet.Common.CurrentUser.Interfaces
{
    using _Project_CheatSheet.Data.Models;

    public interface ICurrentUser
    {

        public Task<User> GetUser();

        public Task<string> GetUserId();

    }
}
