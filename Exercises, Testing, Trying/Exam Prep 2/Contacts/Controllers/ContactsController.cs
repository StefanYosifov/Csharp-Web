namespace Contacts.Controllers
{
    using Contacts.Models.Contacts;
    using Contacts.Services.Contacts;
    using Microsoft.AspNetCore.Mvc;

    public class ContactsController : BaseController
    {
        private readonly IContactService service;

        public ContactsController(IContactService service)
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
            var contacts=await service.GetAllContactsAsync();
            return View(contacts);
        }

        [HttpGet]
        public async Task<IActionResult> Team()
        {
           var teams=await service.GetTeamsContactsAsync();
           return View(teams);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model=new ContactViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddContactViewModel addModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addModel);
            }
            try
            {
               await service.AddContactAsync(addModel);
               return RedirectToAction("All");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToTeam(int id)
        {
            try
            {
                await service.AddToCollection(id);
                return RedirectToAction("Team");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromTeam(int id)
        {
            try
            {
                await service.RemoveFromCollection(id);
                return RedirectToAction("All");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var getContact=await service.GetEditModelById(id);
            return View(getContact);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,AddContactViewModel contactModel)
        {
            try
            {
                await service.EditContact(id,contactModel);
                return RedirectToAction("All");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
