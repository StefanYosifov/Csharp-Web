namespace ForumApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Services.Interfaces;

    public class PostController : Controller
    {
        private readonly IPostService service;

        public PostController(IPostService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var allPosts = await service.getAllPostsAsync();
            return View(allPosts);
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostInputViewModel postModel)
        {
            if (!ModelState.IsValid)
            {
                return View(postModel);
            }

            try
            {
                await service.AddPostAsync(postModel);
            }
            catch (Exception e)
            {
               ModelState.AddModelError(string.Empty,"Unexpected");
               return View(postModel);

            }

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostInputViewModel editModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editModel);
            }

            try
            {
                await service.EditByIdAsync(id,editModel);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty,"Failed to edit a post");
                return View(editModel);
            }

            return RedirectToAction("All");
        }
    }
}
