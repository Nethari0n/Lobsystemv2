namespace Lobsystem.Client.IAPICallers
{
    public interface ICRUDCaller
    {
        Task CreateEntity<T>(T entity) where T : class;
        Task UpdateEntity<T>(T entity) where T : class;
        Task DeleteEntity<T>(T entity) where T : class;
    }
}
