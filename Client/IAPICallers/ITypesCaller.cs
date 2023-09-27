using Lobsystem.Shared.DTO;
using Lobsystem.Shared.Models;

namespace Lobsystem.Client.IAPICallers
{
    public interface ITypesCaller
    {
        Task CreatTypes(CreateTypeDTO type);
        Task UpdateTypes(EditTypeDTO type);
        Task<List<Types>> GetAllTypes();

        Task<List<Types>> TypesPagination(int page, int totalItem);

        Task<List<Types>> SearchType(int page, int totalItem, string search);

        Types GetTypeByID(int id);

        string GetTypeNameByID(int id);

        Task<bool> GetMultiRound(int id);

        Task DeleteType(int id);

        public Task<bool> TypeExists(int id);


        public Task<bool> TypeExists(string TypeName);




    }
}
