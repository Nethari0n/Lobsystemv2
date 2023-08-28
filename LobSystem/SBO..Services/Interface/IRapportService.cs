using SBO.LobSystem.Services.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.LobSystem.Services.Interface
{
    public interface IRapportService
    {
        #region Live Rapport
        List<LiveRapport> GetLiveRapport(int id);
        #endregion

        #region Rapport
        List<EndRapport> GetRapports(int id);
        #endregion
    }
}
