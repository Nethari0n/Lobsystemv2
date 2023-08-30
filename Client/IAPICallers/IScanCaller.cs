using Lobsystem.Shared.Models;

namespace Lobsystem.Client.IAPICallers
{
    public interface IScanCaller
    {
        List<Scanning> GetAllScannings();

        List<Scanning> GetAllScanningsPerUser(int id, int eventID);

        DateTime FindScansDatetime(string uid, int id);

        Scanning GetScan(string uid, int postID);

        bool CheckPostScan(int id, int postID);
    }
}
