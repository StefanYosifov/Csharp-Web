namespace _Project_CheatSheet.Features.Profile
{
    using Common.CurrentUser.Interfaces;
    using GlobalConstants.Profile;
    using Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Route("/profile")]
    public class ProfileController : ApiController
    {
        private readonly ICurrentUser currentUser;

        private readonly IProfileService service;

        public ProfileController(
            IProfileService service,
            ICurrentUser currentUser)
        {
            this.service = service;
            this.currentUser = currentUser;
        }

        [Authorize]
        [HttpGet("myUser")]
        public ActionResult GetMyUserId()
        {
            var userId = currentUser.GetUserId();
            return Ok(userId);
        }


        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfileData(string id)
        {
            var dataResult = await service.GetProfileData(id);
            return Ok(dataResult);
        }

        [Authorize]
        [HttpPatch("update")]
        public async Task<IActionResult> UpdateProfileData(UserEditModel userModel)
        {
            var updateResult = await service.EditProfileData(userModel);
            if (updateResult == null)
            {
                return BadRequest(ProfileMessages.OnUnsuccessfulUserChange);
            }

            return Ok(ProfileMessages.OnSuccessfulUserChange);
        }
    }
}