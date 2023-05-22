namespace _Project_CheatSheet.Features.Resources
{
    using GlobalConstants.Resource;
    using Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Route("/resource")]
    [Authorize]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService resourceService;

        public ResourceController(IResourceService resourceService)
        {
            this.resourceService = resourceService;
        }

        [HttpGet("pages")]
        public IActionResult GetPageCount()
        {
            return Ok(resourceService.GetTotalPage());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllResources(int id)
        {
            var resourcesResult = await resourceService.GetPublicResources(id);
            return Ok(resourcesResult);
        }

        [HttpGet("my")]
        public async Task<IActionResult> GetMyResources()
        {
            var resourcesResult = await resourceService.GetMyResources();
            return Ok(resourcesResult);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetResourceDetails(string id)
        {
            var resourceResult = await resourceService.GetResourceById(id);
            if (resourceResult == null)
            {
                return NotFound("You do not have access to the resource or it does not exist");
            }

            return Ok(resourceResult);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddResource([FromBody] ResourceAddModel resourceAdd)
        {
            var resourceResult = await resourceService.AddResources(resourceAdd);
            if (resourceResult == null)
            {
                return BadRequest(ResourceMessages.OnUnsuccessfulResourceAdd);
            }

            return Ok(ResourceMessages.OnSuccessfulResourceAdd);
        }

        [HttpPatch("edit/{id}")]
        public async Task<IActionResult> EditResource(string id, [FromBody] ResourceEditModel resourceEdit)
        {
            if (!await TryUpdateModelAsync(resourceEdit))
            {
                return NotFound(ResourceMessages.OnInvalidRequestsResourceEdit);
            }

            var resourceResult = await resourceService.EditResource(id, resourceEdit);
            if (resourceResult == null)
            {
                return NotFound(ResourceMessages.OnUnsuccessfulResourceEdit);
            }

            return Ok(ResourceMessages.OnSuccessfulResourceEdit);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> RemoveResource(string id)
        {
            var resourceResult = await resourceService.RemoveResource(id);
            if (resourceResult == null)
            {
                return BadRequest(ResourceMessages.OnUnsuccessfulResourceRemove);
            }

            return Ok(ResourceMessages.OnSuccessfulResourceEdit);
        }
    }
}