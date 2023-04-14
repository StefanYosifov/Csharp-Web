namespace _Project_CheatSheet.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

       //[Authorize]
        public IActionResult Get()
        {
            return Ok("Works");
        }

    }
}