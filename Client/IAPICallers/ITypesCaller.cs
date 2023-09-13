using Lobsystem.Shared.Models;

namespace Lobsystem.Client.IAPICallers
{
    public interface ITypesCaller
    {
        Task<List<Types>> GetAllTypes();

        List<Types> TypesPagination(int page, int totalItem);

        List<Types> SearchType(int page, int totalItem, string search);

        Types GetTypeByID(int id);

        string GetTypeNameByID(int id);

        Task<bool> GetMultiRound(int id);

        void DeleteType(int ID);
    }
}
