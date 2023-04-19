namespace _Project_CheatSheet.Controllers.Resources
{
    using _Project_CheatSheet.Controllers.Resources.Interfaces;
    using _Project_CheatSheet.Controllers.Resources.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;


    public class ResourceController : ControllerBase
    {
        private readonly IResourceService services;

        public ResourceController(IResourceService services)
        {
            this.services = services;
        }

        [Authorize]
        [Route("/resource")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var resources = await services.publicResources();
            return Ok(resources);
        }

        [Authorize]
        [Route("/resource/my")]
        [HttpGet]
        public async Task<IActionResult> MyResources()
        {
            var resources = await services.myResources();
            return Ok(resources);
        }


        [Authorize]
        [Route("/resource/details/{id?}")]
        [HttpGet]
        public async Task<IActionResult> ResourceDetails(string? id)
        {
            var resource = await services.resourceById(id);
            if(resource == null)
            {
                return NotFound("You do not have access to the resource or it does not exist");
            }

            return Ok(resource);
        }

        [Authorize]
        [Route("/resource/add")]
        [HttpPost]
        public async Task<IActionResult> AddResource([FromBody]ResourceAddModel model)
        {
            var result = await services.addResource(model);
            return result == StatusCode(StatusCodes.Status201Created) ? Ok() : BadRequest();
        }
    }
}
