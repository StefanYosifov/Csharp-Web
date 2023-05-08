namespace _Project_CheatSheet.Features.Profile
{
    using _Project_CheatSheet.Common.CurrentUser.Interfaces;
    using _Project_CheatSheet.Controllers;
    using _Project_CheatSheet.Controllers.Profile.Interfaces;
    using _Project_CheatSheet.Controllers.Profile.Models;
    using _Project_CheatSheet.Features.Profile.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("/profile")]
    public class ProfileController : ApiController
    {

        private readonly IProfileService service;
        private readonly ICurrentUser currentUser;

        public ProfileController(IProfileService service,
                                 ICurrentUser currentUser)
        {
            this.service = service;
            this.currentUser = currentUser;
        }

        [Authorize]
        [HttpGet("myuserId")]
        public  ActionResult GetMyUserId()
        {
            var userId = currentUser.GetUserId();
            return Ok(userId);
        }


        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfileData(string id)
        {
            var dataResult = await service.getProfileData(id);
            return Ok(dataResult);
        }

        [Authorize]
        [HttpPatch("update")]
        public async Task<IActionResult> UpdateProfileData(UserEditModel userModel)
        {
            var updateResult = await service.editProfileData(userModel);
            if (updateResult==null)
            {
                return BadRequest(ProfileConstants.onUnsuccessfulUserChange);
            }
            return Ok(ProfileConstants.onSuccessfulUserChange);    
        }
    }
}
