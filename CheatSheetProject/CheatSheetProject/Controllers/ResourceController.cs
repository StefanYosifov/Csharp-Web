namespace CheatSheetProject.Controllers
{
    using CheatSheetProject.Models;
    using CheatSheetProject.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;


    [ApiController]
    public class ResourceController : Controller
    {
        private readonly IResource resources;

        public ResourceController(IResource resources)
        {
            this.resources = resources;
        }




        //Public resourceModels
        public IActionResult Index()
        {
            var publicResource= resources.GetAllPublicResources();
            return Ok(publicResource);
        }

        public IActionResult MyResources(int id)
        {

        }

    }
}
