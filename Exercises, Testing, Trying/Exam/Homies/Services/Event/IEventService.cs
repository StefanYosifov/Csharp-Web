namespace Homies.Services.Event
{
    using Data.Models;
    using Models;
    using Models.EventModels;


    public interface IEventService
    {

        Task<IEnumerable<EventAllViewModel>> GetAllEventsAsync();

        Task<IEnumerable<EventJoinedViewModel>> GetJoinedEventsAsync();

        Task<IEnumerable<TypeViewModel>> GetEventTypesAsync();

        Task AddEvent(EventAddViewModel eventModel);

        Task<EventEditViewModel> GetEventEditAsync(int id);

        Task UpdateEvent(EventEditViewModel editModel);

        Task<EventParticipant> JoinEvent(int id);

        Task LeaveEvent(int id);

        Task<EventDetailViewModel> GetEventDetailAsync(int id);

    }
}
