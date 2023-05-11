using _Project_CheatSheet.Features.Profile.Models;

namespace _Project_CheatSheet.Features.Profile.Interfaces
{
    public interface IProfileService
    {
        public Task<ProfileModel> GetProfileData(string id);

        public Task<UserEditModel> EditProfileData(UserEditModel user);
    }
}