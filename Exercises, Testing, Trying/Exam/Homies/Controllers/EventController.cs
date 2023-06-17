namespace Homies.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.EventModels;
    using Services.Event;

    public class EventController : BaseController
    {
        private readonly IEventService service;

        public EventController(IEventService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var events = await service.GetAllEventsAsync();
            return View(events);
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            var joinedEvents = await service.GetJoinedEventsAsync();
            return View(joinedEvents);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var eventTypes = await service.GetEventTypesAsync();
            var events = new EventAddViewModel()
            {
                Types = eventTypes
            };

            return View(events);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventAddViewModel eventModel)
        {
            if (!ModelState.IsValid)
            {
                return View(eventModel);
            }

            try
            {
                await service.AddEvent(eventModel);
                return RedirectToAction("All");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var eventModel=await service.GetEventEditAsync(id);
            var eventTypes = await service.GetEventTypesAsync();
            eventModel.Types = eventTypes;
            return View(eventModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventEditViewModel editModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editModel);
            }

            try
            {
                await service.UpdateEvent(editModel);
                return RedirectToAction("All");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            try
            {
               var joinedResult=await service.JoinEvent(id);
               if (joinedResult==null)
               {
                   return RedirectToAction("All");
               }
                return RedirectToAction("Joined");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            try
            {
                await service.LeaveEvent(id);
                return RedirectToAction("All");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var getEventDetails = await service.GetEventDetailAsync(id);
                return View(getEventDetails);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


    }
    
}