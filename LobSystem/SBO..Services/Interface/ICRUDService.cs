using System.Threading.Tasks;

namespace SBO.LobSystem.Services.Interface
{
    public interface ICRUDService
    {
        Task CreateEntity<T>(T entity) where T : class;
        Task UpdateEntity<T>(T entity) where T : class;
        Task DeleteEntity<T>(T entity) where T : class;
    }
}
