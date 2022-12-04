using Newtonsoft.Json;
using System.Text;
using WebAppBusMVC.WEB.Models;

namespace WebAppBusMVC.WEB.Services
{
    public class VentaBoletoService
    {

        public static async Task<IEnumerable<DestinoViewModel>> GetDestinos()
        {
            var url = "http://localhost:5276/api/Destino" ;
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(url);

            var apiResponse = await response.Content.ReadAsStringAsync();
            var destinoResponse = JsonConvert.DeserializeObject<IEnumerable<DestinoViewModel>>(apiResponse);

            return destinoResponse;
        }

        public static async Task<DestinoViewModel> GetDestinoById(int id)
        {
            var url = "http://localhost:5276/api/Destino/"+ id.ToString();
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(url);

            var apiResponse = await response.Content.ReadAsStringAsync();
            var destinoResponse = JsonConvert.DeserializeObject<DestinoViewModel>(apiResponse);

            return destinoResponse;
        }

        public static async Task<IEnumerable<OrigenViewModel>> GetOrigenes()
        {
            var url = "http://localhost:5276/api/Origen";
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(url);

            var apiResponse = await response.Content.ReadAsStringAsync();
            var origenResponse = JsonConvert.DeserializeObject<IEnumerable<OrigenViewModel>>(apiResponse);

            return origenResponse;

        }
        

        public static async Task<IEnumerable<DocumentoViewModel>> GetDocumentos()
        {
            var url = "http://localhost:5276/api/Documento";
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(url);

            var apiResponse = await response.Content.ReadAsStringAsync();
            var documentoResponse = JsonConvert.DeserializeObject<IEnumerable<DocumentoViewModel>>(apiResponse);

            return documentoResponse;

        }


        public static async Task<OrigenViewModel> GetOrigenById(int id)
        {
            var url = "http://localhost:5276/api/Origen/" + id.ToString();
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(url);

            var apiResponse = await response.Content.ReadAsStringAsync();
            var origenResponse = JsonConvert.DeserializeObject<OrigenViewModel>(apiResponse);

            return origenResponse;
        }

        public static async Task<IEnumerable<OutputDateNameViewModel>> GetDateName(InputDateViewModel inputDate)
        {

            var url = "http://localhost:5276/api/Usuario/GetOutputDateName";
            var json = JsonConvert.SerializeObject(inputDate);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient.PostAsync(url, data);

            var apiResponse = await response.Content.ReadAsStringAsync();
            var dateResponse = JsonConvert.DeserializeObject<IEnumerable<OutputDateNameViewModel>>(apiResponse);

            return dateResponse;

        }

        public static async Task<IEnumerable<OutProgramacionViajeViewModel>> GetProgramacionViaje(InProgramacionViajeViewModel inProgramacionViaje)
        {

            var url = "http://localhost:5276/api/AsientoProgramacion/GetOutProgramacionViaje";
            var json = JsonConvert.SerializeObject(inProgramacionViaje);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient.PostAsync(url, data);

            var apiResponse = await response.Content.ReadAsStringAsync();
            var dateResponse = JsonConvert.DeserializeObject<IEnumerable<OutProgramacionViajeViewModel>>(apiResponse);

            return dateResponse;

        }
        public static async Task<IEnumerable<AsientoProgramacionResponseViewModel>> GetAsientoProgramacionByProgramacion(int idProgramacion)
        {

            var url = "http://localhost:5276/api/AsientoProgramacion/GetAsientoProgramacionByProgramacion/"+ idProgramacion.ToString();

            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(url);            

            var apiResponse = await response.Content.ReadAsStringAsync();
            var dateResponse = JsonConvert.DeserializeObject<IEnumerable<AsientoProgramacionResponseViewModel>>(apiResponse);

            return dateResponse;

        }
        public static async Task<IEnumerable<OutProgramacionAsientoViewModel>> GetProgramacionAsiento(int idProgramacion)
        {

            var url = "http://localhost:5276/api/AsientoProgramacion/GetOutProgramacionAsiento/" + idProgramacion.ToString();
            var json = JsonConvert.SerializeObject(idProgramacion);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient.PostAsync(url,data);

            var apiResponse = await response.Content.ReadAsStringAsync();
            var dateResponse = JsonConvert.DeserializeObject<IEnumerable<OutProgramacionAsientoViewModel>>(apiResponse);

            return dateResponse;

        }


        


    }
}
