using Lobsystem.Shared.Models;

namespace Lobsystem.Client.IAPICallers
{
    public interface IRegistrationCaller
    {
        Task<List<Registration>> GetAllRegistrationsAsync();
        Task<Registration> GetRegistrationByChipAndEventIdAsync(int id, int eventId);
        Task CreateRegistrationAsync(Registration registration);
        Task UpdateRegistrationAsync(Registration registration);
        Task DeleteRegistrationAsync(int id, int eventId);
    }
}
