namespace _Project_CheatSheet.Controllers.Profile.Interfaces
{
    using _Project_CheatSheet.Controllers.Profile.Models;
    using _Project_CheatSheet.Features.Profile.Models;

    public interface IProfileService
    {

        public Task<ProfileModel> getProfileData(string id);

        public Task<UserEditModel> editProfileData();

    }
}
