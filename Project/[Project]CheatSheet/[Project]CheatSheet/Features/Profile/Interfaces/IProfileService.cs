namespace _Project_CheatSheet.Controllers.Profile.Interfaces
{
    using _Project_CheatSheet.Controllers.Profile.Models;

    public interface IProfileService
    {

        public Task<ProfileModel> getProfileData(string id);

    }
}
