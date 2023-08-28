using Lobsystem.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.LobSystem.Services.Interface
{
    public interface IScanService
    {
        List<Scanning> GetAllScannings();

        List<Scanning> GetAllScanningsPerUser(int id, int eventID);

        DateTime FindScansDatetime(string uid, int id);

        Scanning GetScan(string uid, int postID);

        bool CheckPostScan(int id, int postID);





    }
}
