using Lobsystem.Shared.DTO;

namespace Lobsystem.Client.IAPICallers
{
    public interface IRapportAPICaller
    {
        #region Live Rapport
        Task<List<LiveRapport>> GetLiveRapport(int id);
        #endregion

        #region Rapport
        Task<List<EndRapport>> GetRapports(int id);
        #endregion
    }
}
