namespace Homies.Services.Event
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Models.EventModels;
    using UserService;

    public class EventService : IEventService
    {
        private readonly HomiesDbContext context;
        private readonly IMapper mapper;
        private readonly IUserService userService;


        public EventService(
            HomiesDbContext context,
            IUserService userService,
            IMapper mapper)
        {
            this.context = context;
            this.userService = userService;
            this.mapper = mapper;
        }


        public async Task<IEnumerable<EventAllViewModel>> GetAllEventsAsync()
             => await context.Events.ProjectTo<EventAllViewModel>(mapper.ConfigurationProvider).ToArrayAsync();
        

        public async Task<IEnumerable<EventJoinedViewModel>> GetJoinedEventsAsync()
        {
            var userId=userService.GetUserId();
            return await context.Events
                .Where(e => e.EventParticipants.Any(ep=>ep.HelperId==userId))
                .ProjectTo<EventJoinedViewModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<TypeViewModel>> GetEventTypesAsync()
             => await context.Types.Select(t=>new TypeViewModel()
             {
                 Id = t.Id,
                 Name = t.Name,
             } ).ToArrayAsync();

        public async Task AddEvent(EventAddViewModel eventModel)
        {
            var model=mapper.Map<Event>(eventModel);

            var userId = userService.GetUserId();
            model.OrganiserId=userId;

            await context.Events.AddAsync(model);
            await context.SaveChangesAsync();

        }

        public async Task<EventEditViewModel> GetEventEditAsync(int id)
        {
            string formatter = "yyyy-MM-dd H:mm";
            var userId = userService.GetUserId();
            var eventModel = await context.Events.Where(e => e.OrganiserId == userId && e.Id == id)
                .Select(e=>new EventEditViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    TypeId = e.TypeId,
                    Start = e.Start.ToString(formatter),
                    End = e.End.ToString(formatter),
                    
                }).ToArrayAsync();

            return eventModel.FirstOrDefault();

        }

        public async Task UpdateEvent(EventEditViewModel editModel)
        {
            var userId=userService.GetUserId();
            var eventModel = await context.Events.FindAsync(editModel.Id);

            if (eventModel == null)
            {
                return;
            }

            eventModel.Name = editModel.Name;
            eventModel.Description = editModel.Description;
            eventModel.Start = DateTime.Parse(editModel.Start);
            eventModel.End = DateTime.Parse(editModel.End);
            eventModel.OrganiserId = userId;


            await context.SaveChangesAsync();
        }

        public async Task<EventParticipant> JoinEvent(int id)
        {
            var userId = userService.GetUserId();
            var findEvent =
                await context.Events.AnyAsync(e => e.EventParticipants.Any(ep => ep.EventId == id && ep.HelperId==userId));

            if (findEvent)
            {
                return null;
            }

            EventParticipant newEvent=new EventParticipant()
            {
                EventId = id,
                HelperId = userId
            };

            await context.EventParticipants.AddAsync(newEvent);
            await context.SaveChangesAsync();
            return newEvent;
            
        }

        public async Task LeaveEvent(int id)
        {
            var userId = userService.GetUserId();
            var findEvent = await context.EventParticipants.FirstOrDefaultAsync(e => e.HelperId == userId && e.EventId == id);

            if (findEvent == null)
            {
                return;
            }

            context.Remove(findEvent);
            await context.SaveChangesAsync();
        }

        public async Task<EventDetailViewModel> GetEventDetailAsync(int id)
        {
            Event eventModel = await context.Events.FirstOrDefaultAsync(e => e.Id == id);
            return mapper.Map<EventDetailViewModel>(eventModel);
        }
    }
}