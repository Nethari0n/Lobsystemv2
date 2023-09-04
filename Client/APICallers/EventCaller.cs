using Lobsystem.Client.IAPICallers;
using Lobsystem.Shared.DTO;
using Lobsystem.Shared.Models;
using System.Net.Http.Json;

namespace Lobsystem.Client.APICallers
{
    public class EventCaller : IEventCaller
    {

        private readonly HttpClient _httpClient;

        public EventCaller(HttpClient httpClient)
        {
            _httpClient = httpClient;   
        }

        public async void AddEvent(Event events)
        {
            await _httpClient.PostAsJsonAsync("Event",events);

        }

        //public async Event FindEvent(DateTime time, string name)
        //{
        //    var test = await _httpClient.GetFromJsonAsync<Event>("");
        //}

        public async Task<List<EventTypeDTO>> GetAllEvents()
        {
            var test = await _httpClient.GetFromJsonAsync<List<EventTypeDTO>>("Event");
            return test.ToList();
        }

        public async Task<Event> GetEventByID(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Event>($"Event/{id}");
            return response;
        }
    }
}
