using Lobsystem.Shared.Models;

namespace Lobsystem.Client.IAPICallers
{
    public interface ITypesCaller
    {
        Task<List<Types>> GetAllTypes();

        Task<List<Types>> TypesPagination(int page, int totalItem);

        Task<List<Types>> SearchType(int page, int totalItem, string search);

        Types GetTypeByID(int id);

        string GetTypeNameByID(int id);

        Task<bool> GetMultiRound(int id);

        void DeleteType(int ID);

        public Task<bool> TypeExists(int ID);


        public Task<bool> TypeExists(string TypeName);

    }
}
