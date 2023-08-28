using Microsoft.EntityFrameworkCore;
using SBO.Lobsystem.Domain.Data;
using Lobsystem.Shared.Models;
using SBO.LobSystem.Services.Classes;
using SBO.LobSystem.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.LobSystem.Services.Services
{
    public class RapportService : IRapportService
    {
        private readonly ApplicationDBContext _lobsContext;
        public RapportService(ApplicationDBContext lobsContext)
        {
            _lobsContext = lobsContext;
        }
        #region LiveRapport
        /// <summary>
        /// Gets Live rapport for the liverapport site
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<LiveRapport> GetLiveRapport(int id)
        {
            try
            {
                List<LiveRapport> liveRapports = new List<LiveRapport>();
                var liveRapportsDict = new Dictionary<int, LiveRapport>();

                var dataset = _lobsContext.Events
                    .Where(e => e.EventID == id)
                    .Include(p => p.Posts)
                        .ThenInclude(s => s.Scannings.Where(d => d.IsDeleted == false))
                            .ThenInclude(c => c.Chip.ChipGroup)
                                .ThenInclude(g => g.Group)
                    .AsNoTracking()
                    .ToList();

                foreach ( var item in dataset )
                {
                    TimeSpan eventStartTS = DateTime.Now.Subtract(item.StartDate);

                    foreach ( var post in item.Posts )
                    {
                        var sortedScannings = post.Scannings
                            .OrderBy(c => c.ChipID)
                            .ThenBy(t => t.TimeStamp)
                            .ToList();

                        foreach ( var scanning in sortedScannings )
                        {
                            int chipId = scanning.ChipID;
                            double distance = post.Distance;

                            if ( !liveRapportsDict.ContainsKey(chipId) )
                            {
                                var newLiveRapport = new LiveRapport
                                {
                                    TimeSinceStart = eventStartTS,
                                    ChipID = chipId,
                                    LaanerID = scanning.Chip.LaanerID,
                                    Recordings = 0,
                                    TimeBetweenStartAndLatestScan = TimeSpan.Zero,
                                    Group1 = string.Empty,
                                    Group2 = string.Empty,
                                    DistanceRun = string.Empty
                                };

                                liveRapportsDict.Add(chipId, newLiveRapport);
                            }

                            var liveRapport = liveRapportsDict[chipId];

                            liveRapport.Recordings++;
                            liveRapport.LatestRecord = scanning.TimeStamp;
                            liveRapport.TimeSinceLatestScan = DateTime.Now.Subtract(scanning.TimeStamp);
                            liveRapport.TimeBetweenStartAndLatestScan = scanning.TimeStamp.Subtract(item.StartDate);

                            foreach ( var chipGroup in scanning.Chip.ChipGroup )
                            {
                                if ( chipGroup.GroupNumber == 1 )
                                    liveRapport.Group1 = chipGroup.Group.GroupName;
                                else if ( chipGroup.GroupNumber == 2 )
                                    liveRapport.Group2 = chipGroup.Group.GroupName;
                            }

                            if ( liveRapport.DistanceRun == string.Empty )
                            {
                                liveRapport.DistanceRun = $"{distance} M";
                            }
                            else
                            {
                                double existingDistance = double.Parse(liveRapport.DistanceRun.Split(' ')[0]);
                                double updatedDistance = existingDistance + distance;
                                liveRapport.DistanceRun = $"{updatedDistance} M";
                            }

                            liveRapportsDict[chipId] = liveRapport;
                        }
                    }
                }

                liveRapports = liveRapportsDict.Values.ToList();


                #region Old code

                //int temp = 0;
                //string tempDistance;
                //List<LiveRapport> liveRapports = new List<LiveRapport>();

                ////Data set used for Liverapport

                //var dataset = _lobsContext.Events.Where(e => e.EventID == id)
                //                                   .Include(p => p.Posts)
                //                                        .ThenInclude(s => s.Scannings.Where(d => d.IsDeleted == false))
                //                                            .ThenInclude(c => c.Chip)
                //                                                .ThenInclude(cg => cg.ChipGroup)
                //                                                    .ThenInclude(g => g.Group)
                //                                                    .AsNoTracking()
                //                                                    .ToList();



                //foreach ( var item in dataset )
                //{

                //    TimeSpan eventStartTS = DateTime.Now.Subtract(item.StartDate);                                      //gets timespan from Eventstart

                //    foreach ( var post in item.Posts )
                //    {
                //        LiveRapport liveRapport = new();

                //        if ( post.Scannings.Any() )
                //        {
                //            post.Scannings = post.Scannings.OrderBy(c => c.ChipID).ThenBy(t => t.TimeStamp).ToList();   // Sorts list of scannings by chip ID then Timestamp



                //            foreach ( var scanning in post.Scannings )
                //            {


                //                liveRapport.TimeSinceStart = eventStartTS;

                //                liveRapport.ChipID = scanning.ChipID;

                //                liveRapport.Recordings = post.Scannings.Where(x => x.ChipID == scanning.ChipID).Count();

                //                liveRapport.LatestRecord = post.Scannings.Where(x => x.ChipID == scanning.ChipID).Last().TimeStamp;

                //                liveRapport.TimeSinceLatestScan = DateTime.Now.Subtract(scanning.TimeStamp);
                //                liveRapport.TimeSinceStart = DateTime.Now.Subtract(item.StartDate);
                //                liveRapport.TimeBetweenStartAndLatestScan = scanning.TimeStamp.Subtract(item.StartDate);

                //                foreach ( var chipGroup in scanning.Chip.ChipGroup )
                //                {
                //                    if ( chipGroup.GroupNumber == 1 )
                //                        liveRapport.Group1 = chipGroup.Group.GroupName;
                //                    else if ( chipGroup.GroupNumber == 2 )
                //                        liveRapport.Group2 = chipGroup.Group.GroupName;
                //                }

                //                liveRapport.LaanerID = scanning.Chip.LaanerID;
                //                double distance = post.Distance * scanning.Chip.Scanning.Count();
                //                if ( distance > 1000 )
                //                {
                //                    distance /= 1000;
                //                    tempDistance = $"{distance} KM";
                //                }
                //                else
                //                    tempDistance = $"{distance} M";

                //                if ( temp != liveRapport.ChipID && liveRapport.ChipID > 0 )
                //                {
                //                    liveRapport.DistanceRun = tempDistance;
                //                    temp = liveRapport.ChipID;
                //                    liveRapports.Add(liveRapport);
                //                    liveRapport = new();

                //                }
                //            }

                //        }
                //    }
                //}

                #endregion

                //Returns and orders the Liverapport by recordings and latestrecord
                return liveRapports.OrderByDescending(x => x.Recordings).ThenBy(x => x.LatestRecord).ToList();
            }
            catch ( Exception )
            {

                throw;
            }
        }

        #endregion

        #region Rapport

        /// <summary>
        /// Gets a end rapport for the rapport site
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<EndRapport> GetRapports(int id)
        {
            try
            {

                List<EndRapport> endRapports = new List<EndRapport>();
                var endRapportsDict = new Dictionary<int, EndRapport>();

                var dataset = _lobsContext.Events
                    .Where(e => e.EventID == id)
                    .Include(p => p.Posts)
                        .ThenInclude(s => s.Scannings.Where(d => d.IsDeleted == false))
                            .ThenInclude(c => c.Chip.ChipGroup)
                                .ThenInclude(g => g.Group)
                    .AsNoTracking()
                    .ToList();

                foreach ( var item in dataset )
                {
                    TimeSpan eventStartTS = DateTime.Now.Subtract(item.StartDate);

                    foreach ( var post in item.Posts )
                    {
                        var sortedScannings = post.Scannings
                            .OrderBy(c => c.ChipID)
                            .ThenBy(t => t.TimeStamp)
                            .ToList();

                        foreach ( var scanning in sortedScannings )
                        {
                            int chipId = scanning.ChipID;
                            double distance = post.Distance;

                            if ( !endRapportsDict.ContainsKey(chipId) )
                            {
                                var newEndRapport = new EndRapport
                                {
                                    ChipID = scanning.ChipID,
                                    Recordings = 0,
                                    LatestRecord = DateTime.MinValue,
                                    TimeBetweenStartAndLatestScan = TimeSpan.Zero,
                                    Group1 = string.Empty,
                                    Group2 = string.Empty,
                                    FastestScan = TimeSpan.MaxValue,
                                    DistanceRun = string.Empty
                                };

                                endRapportsDict.Add(chipId, newEndRapport);
                            }

                            var endRapport = endRapportsDict[chipId];

                            endRapport.LaanerID = scanning.Chip.LaanerID;
                            endRapport.Recordings++;
                            endRapport.LatestRecord = scanning.TimeStamp;
                            endRapport.TimeSinceLatestScan = DateTime.Now.Subtract(scanning.TimeStamp);
                            endRapport.TimeBetweenStartAndLatestScan = scanning.TimeStamp.Subtract(item.StartDate);
                            endRapport.TimeBetweenStartAndLatestScan = scanning.TimeStamp.Subtract(item.StartDate);

                            foreach ( var chipGroup in scanning.Chip.ChipGroup )
                            {
                                if ( chipGroup.GroupNumber == 1 )
                                    endRapport.Group1 = chipGroup.Group.GroupName;
                                else if ( chipGroup.GroupNumber == 2 )
                                    endRapport.Group2 = chipGroup.Group.GroupName;
                            }

                            for ( int i = 0; i < scanning.Chip.Scanning.Count(); i++ )
                            {
                                DateTime time1 = scanning.Chip.Scanning[i].TimeStamp;
                                DateTime time2;
                                TimeSpan fastesttime = new();

                                if ( i == 0 )
                                {
                                    time2 = scanning.Chip.Scanning[0].TimeStamp;
                                    fastesttime = item.StartDate.Subtract(time2);
                                    if ( endRapport.FastestScan > fastesttime )
                                        endRapport.FastestScan = fastesttime.Duration();
                                }
                                //Finds the fastest time
                                if ( i < scanning.Chip.Scanning.Count - 1 )
                                {
                                    time2 = scanning.Chip.Scanning[i + 1].TimeStamp;
                                    fastesttime = time1.Subtract(time2);
                                    if ( endRapport.FastestScan > fastesttime )
                                        endRapport.FastestScan = fastesttime.Duration();
                                }
                            }

                            if ( endRapport.DistanceRun == string.Empty )
                            {
                                endRapport.DistanceRun = $"{distance} M";
                            }
                            else
                            {
                                double existingDistance = double.Parse(endRapport.DistanceRun.Split(' ')[0]);
                                double updatedDistance = existingDistance + distance;
                                endRapport.DistanceRun = $"{updatedDistance} M";
                            }

                            endRapportsDict[chipId] = endRapport;
                        }
                    }
                }

                endRapports = endRapportsDict.Values.ToList();

                return endRapports.OrderByDescending(x => x.Recordings).ThenBy(x => x.LatestRecord).ToList();
                
                #region old?

                //List<EndRapport> rapports = new();
                //var liveRapportsDict = new Dictionary<int, LiveRapport>();

                //int temp = 0;
                ////Data set used for Endrapport
                //var dataset = _lobsContext.Events.Where(e => e.EventID == id)
                //                                   .Include(p => p.Posts)
                //                                        .ThenInclude(s => s.Scannings.Where(d => d.IsDeleted == false))
                //                                            .ThenInclude(c => c.Chip)
                //                                                .ThenInclude(cg => cg.ChipGroup)
                //                                                    .ThenInclude(g => g.Group)
                //                                                    .AsNoTracking();

                //foreach ( var item in dataset )
                //{
                //    foreach ( var post in item.Posts )
                //    {
                //        EndRapport endRapport = new();

                //        if ( post.Scannings.Any() )
                //        {
                //            post.Scannings = post.Scannings
                //                            .OrderBy(c => c.ChipID)
                //                            .ThenBy(t => t.TimeStamp).ToList();


                //            foreach ( var scanning in post.Scannings )
                //            {

                //                endRapport = new();


                //                endRapport.ChipID = scanning.ChipID;

                //                endRapport.Recordings = post.Scannings.Where(x => x.ChipID == scanning.ChipID).Count();

                //                endRapport.LatestRecord = post.Scannings.Where(x => x.ChipID == scanning.ChipID).Last().TimeStamp;


                //                endRapport.TimeBetweenStartAndLatestScan = scanning.TimeStamp.Subtract(item.StartDate);

                //                foreach ( var chipGroup in scanning.Chip.ChipGroup )
                //                {
                //                    if ( chipGroup.GroupNumber == 1 )
                //                        endRapport.Group1 = chipGroup.Group.GroupName;
                //                    else if ( chipGroup.GroupNumber == 2 )
                //                        endRapport.Group2 = chipGroup.Group.GroupName;
                //                }

                //                for ( int i = 0; i < scanning.Chip.Scanning.Count(); i++ )
                //                {
                //                    DateTime time1 = scanning.Chip.Scanning[i].TimeStamp;
                //                    DateTime time2;
                //                    TimeSpan fastesttime = new();

                //                    if ( i == 0 )
                //                    {
                //                        time2 = scanning.Chip.Scanning[0].TimeStamp;
                //                        fastesttime = item.StartDate.Subtract(time2);
                //                        if ( endRapport.FastestScan > fastesttime )
                //                            endRapport.FastestScan = fastesttime.Duration();
                //                    }
                //                    //Finds the fastest time
                //                    if ( i < scanning.Chip.Scanning.Count - 1 )
                //                    {
                //                        time2 = scanning.Chip.Scanning[i + 1].TimeStamp;
                //                        fastesttime = time1.Subtract(time2);
                //                        if ( endRapport.FastestScan > fastesttime )
                //                            endRapport.FastestScan = fastesttime.Duration();
                //                    }
                //                }

                //                endRapport.LaanerID = scanning.Chip.LaanerID;
                //                double distance = post.Distance * scanning.Chip.Scanning.Count();
                //                if ( distance > 1000 )
                //                {
                //                    distance /= 1000;
                //                    endRapport.DistanceRun = $"{distance} KM";
                //                }
                //                else
                //                    endRapport.DistanceRun = $"{distance} M";


                //                if ( temp != endRapport.ChipID && endRapport.ChipID > 0 )
                //                {
                //                    temp = endRapport.ChipID;
                //                    rapports.Add(endRapport);
                //                    endRapport = new();
                //                }


                //            }

                //        }
                //    }
                //}

                #endregion
                //return rapports.OrderByDescending(x => x.Recordings).ThenBy(x => x.LatestRecord).ToList();

            }
            catch ( Exception )
            {

                throw;
            }



        }

        #endregion

    }
}
