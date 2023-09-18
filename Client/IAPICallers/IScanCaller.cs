using Lobsystem.Shared.DTO;
using Lobsystem.Shared.Models;

namespace Lobsystem.Client.IAPICallers
{
    public interface IScanCaller
    {
        Task<List<Scanning>> GetAllScannings();

        Task<List<Scanning>> GetAllScanningsPerUser(int id, int eventID);

        Task<DateTime> FindScansDatetime(string uid, int id);

        Task<Scanning> GetScan(string uid, int postID);

        Task CreateScan(ScanningDTO scanning);
        Task CreateScans(List<ScanningDTO> scans);
        Task DeleteScan(int id);

        //bool CheckPostScan(int id, int postID);
    }
}
