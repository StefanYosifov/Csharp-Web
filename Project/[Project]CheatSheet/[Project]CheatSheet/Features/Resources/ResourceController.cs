﻿namespace _Project_CheatSheet.Controllers.Resources
{
    using _Project_CheatSheet.Controllers.Resources.Interfaces;
    using _Project_CheatSheet.Controllers.Resources.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("/resource")]
    [Authorize]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService resourceService;

        public ResourceController(IResourceService resourceService)
        {
            this.resourceService = resourceService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllResources()
        {
            var resources = await resourceService.GetPublicResources();
            return Ok(resources);
        }

        [HttpGet("my")]
        public async Task<ActionResult> GetMyResources()
        {
            var resources = await resourceService.GetMyResources();
            return Ok(resources);
        }

        [HttpGet("details/{id}")]
        public async Task<ActionResult> GetResourceDetails(string id)
        {
            var resource = await resourceService.GetResourceById(id);
            if (resource == null)
            {
                return NotFound("You do not have access to the resource or it does not exist");
            }
            return Ok(resource);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddResource([FromBody] ResourceAddModel resourceAdd)
        {
            return await resourceService.AddResources(resourceAdd);
        }
    }
}