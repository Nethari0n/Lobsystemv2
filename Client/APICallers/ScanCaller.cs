using Lobsystem.Client.IAPICallers;
using Lobsystem.Shared.Models;

namespace Lobsystem.Client.APICallers
{
    public class ScanCaller : IScanCaller
    {
        public bool CheckPostScan(int id, int postID)
        {
            throw new NotImplementedException();
        }

        public DateTime FindScansDatetime(string uid, int id)
        {
            throw new NotImplementedException();
        }

        public List<Scanning> GetAllScannings()
        {
            throw new NotImplementedException();
        }

        public List<Scanning> GetAllScanningsPerUser(int id, int eventID)
        {
            throw new NotImplementedException();
        }

        public Scanning GetScan(string uid, int postID)
        {
            throw new NotImplementedException();
        }
    }
}
