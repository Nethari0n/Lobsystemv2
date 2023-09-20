using Blazored.Toast;
using Blazored.Toast.Services;
using Lobsystem.Client.IAPICallers;
using Lobsystem.Shared.DTO;
using Lobsystem.Shared.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Lobsystem.Client.APICallers
{
    public class EventCaller : IEventCaller
    {

        private readonly HttpClient _httpClient;

        public EventCaller(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddEvent(EventPostsDTO events)
        {
            try
            {
                var jsoncontet = JsonSerializer.Serialize(events);
                var response2 = await _httpClient.PostAsync("Event", new StringContent(jsoncontet, Encoding.UTF8, "application/json"));
                response2.EnsureSuccessStatusCode();

            }
            catch (Exception)
            {

                throw;
            }


        }



        //public async Event FindEvent(DateTime time, string name)
        //{
        //    var test = await _httpClient.GetFromJsonAsync<Event>("");
        //}

        public async Task<List<EventTypeDTO>> GetAllEvents()
        {
            var response = await _httpClient.GetFromJsonAsync<List<EventTypeDTO>>("Event");
            return response.ToList();
        }

        public async Task<Event> GetEventByID(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Event>($"Event/{id}");
            return response;
        }
        public async Task<DateTime> GetEventByIDStartDate(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Event>($"Event/{id}");
            return response.StartDate;
        }

        public async Task<DateTime> GetEventByIDEndDate(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Event>($"Event/{id}");
            return response.EndDate;
        }

        public async Task<EditEventPostDTO> GetEditEventPost(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<EditEventPostDTO>($"Event/GetEditEventPost/{id}");
            return response;
        }

        public async Task UpdateEventPosts(EditEventDTO editEventDTO)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync<EditEventDTO>("Event/UpdateEvent", editEventDTO);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
