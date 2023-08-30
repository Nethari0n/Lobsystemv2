using Lobsystem.Client.IAPICallers;
using Lobsystem.Shared.Models;

namespace Lobsystem.Client.APICallers
{
    public class TypesCaller : ITypesCaller
    {
        public void DeleteType(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Types> GetAllTypes()
        {
            throw new NotImplementedException();
        }

        public bool GetMultiRound(int id)
        {
            throw new NotImplementedException();
        }

        public Types GetTypeByID(int id)
        {
            throw new NotImplementedException();
        }

        public string GetTypeNameByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Types> SearchType(int page, int totalItem, string search)
        {
            throw new NotImplementedException();
        }

        public List<Types> TypesPagination(int page, int totalItem)
        {
            throw new NotImplementedException();
        }
    }
}
