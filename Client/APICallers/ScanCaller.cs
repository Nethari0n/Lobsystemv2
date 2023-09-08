using Lobsystem.Client.IAPICallers;
using Lobsystem.Shared.DTO;
using Lobsystem.Shared.Models;
using System.Net.Http.Json;

namespace Lobsystem.Client.APICallers
{
    public class ScanCaller : IScanCaller
    {
        private readonly HttpClient _httpClient;
        public ScanCaller(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        //public bool CheckPostScan(int id, int postID)
        //{
        //    try
        //    {
        //        var response = await
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public async Task<DateTime> FindScansDatetime(string uid, int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<DateTime>($"Scan/{uid}/{id}/datetime");
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task CreateScan(ScanningDTO scanning)
        {
            try
            {
                var test =  await _httpClient.PostAsJsonAsync("Scan/Test",scanning);
                
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public Task<List<Scanning>> GetAllScannings()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Scanning>> GetAllScanningsPerUser(int id, int eventID)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<Scanning>>($"Scan/{id}/{eventID}");               
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Scanning> GetScan(string uid, int postID)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<Scanning>($"Scan/{uid}/{postID}");
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
