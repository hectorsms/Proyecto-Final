using System.Text;
using Newtonsoft.Json;
using WebAppBusMVC.WEB.Models;

namespace WebAppBusMVC.WEB.Services
{
    public class UsuarioService
    {
        public static async Task<UsersLoginResponseViewModel> Login(UsersAuthenticationViewModel auth)
        {
        
            var url = "http://localhost:5276/api/Usuario/Login";
            var json = JsonConvert.SerializeObject(auth);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient.PostAsync(url, data);

            var apiResponse = await response.Content.ReadAsStringAsync();
            var userResponse = JsonConvert.DeserializeObject<UsersLoginResponseViewModel>(apiResponse);

            return userResponse;

        }
    }
}
