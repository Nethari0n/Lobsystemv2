using Microsoft.EntityFrameworkCore;
using SBO.Lobsystem.Domain.Data;
using Lobsystem.Shared.Models;
using SBO.LobSystem.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBO.LobSystem.Services.Services
{
    public class ScanService : IScanService
    {
        private readonly ApplicationDBContext _lobsContext;
        private readonly IChipGroupRegistrationService _chipGroupService;

        public ScanService(ApplicationDBContext lobsContext, IChipGroupRegistrationService chipGroupService)
        {
            _lobsContext = lobsContext;
            _chipGroupService = chipGroupService;
        }

        #region Scan




        public List<Scanning> GetAllScannings() => _lobsContext.Scannings.AsNoTracking().ToList();


        public List<Scanning> GetAllScanningsPerUser(int id, int eventId)
        {
            List<Scanning> list = new();
            var dataset = _lobsContext.Chips
                                            .Where(e => e.ChipID == id)
                                            .Include(s => s.Scanning.Where(d => d.IsDeleted == false && d.Post.EventID == eventId))
                                            .ThenInclude(x => x.Post)
                                            .AsNoTracking();
            foreach ( var chip in dataset )
            {
                foreach ( var scanning in chip.Scanning )
                {
                    if ( scanning.Post.EventID == eventId )
                    {
                        Scanning scanningDTO = new();

                        scanningDTO.ChipID = chip.ChipID;
                        scanningDTO.ScanningID = scanning.ScanningID;
                        scanningDTO.TimeStamp = scanning.TimeStamp;
                        scanningDTO.PostID = scanning.PostID;
                        list.Add(scanningDTO);
                    }

                }
            }

            return list;
        }

        public DateTime FindScansDatetime(string uid, int id)
        {
            int chipID = _chipGroupService.GetChipIDByUID(uid);

            if ( _lobsContext.Scannings.Where(x => x.ChipID == chipID && x.PostID == id).Count() != 0 )
            {
                if ( _lobsContext.Scannings.Where(x => x.ChipID == chipID && x.PostID == id).Count() > 1 )
                {
                    var context = _lobsContext.Scannings.Where(x => x.ChipID == chipID && x.PostID == id).AsNoTracking().AsEnumerable().Last();

                    return context.TimeStamp;
                }
                else
                {
                    var context = _lobsContext.Scannings.Where(x => x.ChipID == chipID && x.PostID == id).AsNoTracking().FirstOrDefault();

                    return context.TimeStamp;
                }
            }

            return DateTime.Now.AddSeconds(-30);
        }

        public Scanning GetScan(string uid, int postID)
        {
            int chipID = _chipGroupService.GetChipIDByUID(uid);

            Scanning scan = new Scanning
            {
                ChipID = chipID,
                PostID = postID,
                TimeStamp = DateTime.Now
            };
            return scan;
        }

        public void DeleteScan(int id)
        {
            Scanning scanning = _lobsContext.Scannings.Where(x => x.ScanningID == id).AsNoTracking().FirstOrDefault();

            scanning.IsDeleted = true;

            _lobsContext.Scannings.Update(scanning);
            _lobsContext.SaveChanges();
        }

        /// <summary>
        /// Checks for double scan on the same post
        /// </summary>
        /// <returns></returns>
        public bool CheckPostScan(int id, int postID)
        {
            return _lobsContext.Scannings.Any(x => x.ChipID == id && x.PostID == postID) ? true : false;
        }

        public Scanning GetScanById(int id)
        {
            return _lobsContext.Scannings.Where(x => x.ScanningID == id).SingleOrDefault();
        }

        //public async Task<List<Scanning>> AddScansFromListAsync(List<Scanning> list)
        //{
        //    for ( int i = 0; i < list.Count; i++ )
        //    {
        //        await AddScanningAsync(list[i]);
        //        list.Remove(list[i]);
        //    }

        //    return list;
        //}

        #endregion
    }

}
