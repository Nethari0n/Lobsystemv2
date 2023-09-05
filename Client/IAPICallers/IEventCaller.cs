using Lobsystem.Shared.DTO;
using Lobsystem.Shared.Models;

namespace Lobsystem.Client.IAPICallers
{
    public interface IEventCaller
    {
        void AddEvent(Event events);

        //Event FindEvent(DateTime time, string name);

        Task<List<EventTypeDTO>> GetAllEvents();

        Task<Event> GetEventByID(int id);

        Task<DateTime> GetEventByIDStartDate(int id);
        Task<DateTime> GetEventByIDEndDate(int id);
    }
}
