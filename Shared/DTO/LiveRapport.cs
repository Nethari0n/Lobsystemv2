using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobsystem.Shared.DTO
{
    public class LiveRapport
    {
        public int ChipID { get; set; }
        public string LaanerID { get; set; }
        public string Group1 { get; set; }
        public string Group2 { get; set; }
        public DateTime LatestRecord { get; set; }
        public int Recordings { get; set; }
        public string DistanceRun { get; set; }
        public TimeSpan TimeBetweenStartAndLatestScan { get; set; }
        public TimeSpan TimeSinceStart { get; set; }
        public TimeSpan TimeSinceLatestScan { get; set; }

    }
}
