namespace MVCIntroduction.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MVCIntroduction.Models;
    using System.Diagnostics;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "This a title";
            ViewData["People"] = new string[] { "Pesho", "Gosho", "Ivo" };

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {


            return View();
        }

        public IActionResult Numbers()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NumbersToN()
        {

            return View();
        }

        [HttpPost]
        public IActionResult NumbersToN(int count = 1)
        {
            ViewData["count"]=count;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}