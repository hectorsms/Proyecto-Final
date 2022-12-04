using Newtonsoft.Json;
using System.Security.Policy;
using System.Text;
using WebAppBusMVC.WEB.Models;

namespace WebAppBusMVC.WEB.Services
{
    public class ClienteService
    {
        public static async Task<IEnumerable<ClienteCreateViewModel>> GetCliente()
        {
            var url = "http://localhost:5276/api/Cliente";
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(url);


            var apiResponse = await response.Content.ReadAsStringAsync();
            var ClienteResponse = JsonConvert.DeserializeObject<IEnumerable<ClienteCreateViewModel>>(apiResponse);

            return ClienteResponse;
        }


        public static async Task<bool> InsertCliente(ClienteInsertViewModel cliente)
        {
            var url = "http://localhost:5276/api/Cliente";
            using var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(cliente);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var response = await httpClient.PostAsync(url, data);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResultViewModel>(apiResponse);

            return result.response;

        }


        public static async Task<ClienteViewModel> InsertClienteById(int id)
        {
            var url = "http://localhost:5276/api/Cliente/" + id.ToString();
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(url);
            var apiResponse = await response.Content.ReadAsStringAsync();
            var Clienteresponse = JsonConvert.DeserializeObject<ClienteViewModel>(apiResponse);

            return Clienteresponse;


        }

        public static async Task<bool> Insertcliente(ClienteViewModel cliente)
        {
            var url = "http://localhost:5276/api/Cliente";
            using var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(cliente);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var response = await httpClient.PostAsync(url, data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResultViewModel>(apiResponse);

            return result.response;
        }


        public static async Task<bool> DeleteCliente(int id)
        {
            var url = "http://localhost:5276/api/Cliente/" + id.ToString();
            using var httpClient = new HttpClient();
            using var response = await httpClient
                .DeleteAsync(url);
            if ((int)response.StatusCode == 404)
                    return false;
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResultViewModel>(apiResponse);

            return result.response;

        
    
}
        public static async Task<bool> UpdateCustomer(ClienteViewModel clientes)
        {
            var url = "http://localhost:5276/api/Cliente/" + clientes.IdCliente.ToString();
            using var httpClient = new HttpClient();

            var json = JsonConvert.SerializeObject(clientes);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var response = await httpClient.PutAsync(url, data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResultViewModel>(apiResponse);

            return result.response;
        }

    }


}

