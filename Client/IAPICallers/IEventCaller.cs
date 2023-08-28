using Lobsystem.Shared.Models;

namespace Lobsystem.Client.IAPICallers
{
    public interface IEventCaller
    {
        void AddEvent(Event events);

        //Event FindEvent(DateTime time, string name);

        Task<List<Event>> GetAllEvents();

        Task<Event> GetEventByID(int id);

    }
}
