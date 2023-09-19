using Lobsystem.Shared.DTO;
using Lobsystem.Shared.Models;

namespace Lobsystem.Client.IAPICallers
{
    public interface IEventCaller
    {
        Task AddEvent(EventPostsDTO events);

        //Event FindEvent(DateTime time, string name);

        Task<List<EventTypeDTO>> GetAllEvents();

        Task<Event> GetEventByID(int id);

        Task<EditEventPostDTO> GetEditEventPost(int id);
        Task UpdateEventPosts(EditEventDTO editEventPostDTO);

        Task<DateTime> GetEventByIDStartDate(int id);
        Task<DateTime> GetEventByIDEndDate(int id);
    }
}
