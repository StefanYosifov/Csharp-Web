namespace _Project_CheatSheet.Features.Profile
{
    using _Project_CheatSheet.Controllers;
    using _Project_CheatSheet.Controllers.Profile.Interfaces;
    using _Project_CheatSheet.Controllers.Profile.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ProfileController:ApiController
    {

        private readonly IProfileService service;

        public ProfileController(IProfileService service)
        {
            this.service = service;
        }

        [Authorize]
        [HttpGet]
        [Route("/profile")]
        public async Task<ActionResult<ProfileModel>> GetProfileData()
        {
            var dataResult = await service.getProfileData();
            return Ok(dataResult);
        }
    }
}
