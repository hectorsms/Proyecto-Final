using Newtonsoft.Json;
using System.Text;
using WebAppBusMVC.WEB.Models;

namespace WebAppBusMVC.WEB.Services
{
    public class BusService
    {
        public static async Task<IEnumerable<BusCreateViewModel>> Getbus()
        {
            var url = "http://localhost:5276/api/Bus";
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(url);


            var apiResponse = await response.Content.ReadAsStringAsync();
            var ClienteResponse = JsonConvert.DeserializeObject<IEnumerable<BusCreateViewModel>>(apiResponse);

            return ClienteResponse;
        }


        public static async Task<bool> InsertBus(BusInsertViewModel bus)
        {
            var url = "http://localhost:5276/api/Bus";
            using var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(bus);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var response = await httpClient.PostAsync(url, data);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResultViewModel>(apiResponse);

            return result.response;

        }



        public static async Task<bool> InsertBus(BusViewModel bus)
        {
            var url = "http://localhost:5276/api/Bus";
            using var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(bus);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var response = await httpClient.PostAsync(url, data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResultViewModel>(apiResponse);

            return result.response;
        }


    }
}