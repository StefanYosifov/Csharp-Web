namespace _Project_CheatSheet.Features.Profile
{
    using _Project_CheatSheet.Common.CurrentUser.Interfaces;
    using _Project_CheatSheet.Controllers;
    using _Project_CheatSheet.Controllers.Profile.Interfaces;
    using _Project_CheatSheet.Controllers.Profile.Models;
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
        public async Task<ActionResult> GetMyUserId()
        {
            var userId = await currentUser.GetUserId();
            return Ok(userId);
        }


        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileModel>> GetProfileData(string id)
        {
            var dataResult = await service.getProfileData(id);
            return Ok(dataResult);
        }
    }
}
