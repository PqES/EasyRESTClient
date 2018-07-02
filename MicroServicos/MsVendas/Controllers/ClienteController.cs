using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MsVendas.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddCustomer(string name, string cpf, string email)
        {
            using (var client = new HttpClient())
            {

                var requestParams = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("name", name),
                    new KeyValuePair<string, string>("cpf", cpf),
                    new KeyValuePair<string, string>("email", email)
                };

                var requestParamsFormUrlEncoded = new FormUrlEncodedContent(requestParams);
                var tokenServiceResponse = await client.PostAsync("http://177.105.34.182:5002/api/Customer/AddCustomer", requestParamsFormUrlEncoded);
                var responseString = await tokenServiceResponse.Content.ReadAsStringAsync();

                var responseCode = tokenServiceResponse.StatusCode;
                var responseMsg = new HttpResponseMessage(responseCode)
                {
                    Content = new StringContent(responseString, Encoding.UTF8, "application/json")
                };

                return View();
            }
        }


        public async Task<IActionResult> GetAllClientes()
        {
            using (var client = new HttpClient())
            {
                var tokenServiceResponse = await client.GetAsync("http://177.105.34.182:5002/api/Customer/GetAllClientes");
                var responseString = await tokenServiceResponse.Content.ReadAsStringAsync();

                var responseCode = tokenServiceResponse.StatusCode;
                var responseMsg = new HttpResponseMessage(responseCode)
                {
                    Content = new StringContent(responseString, Encoding.UTF8, "application/json")
                };

                return View();
            }
        }


        public async Task<IActionResult> GetClientePorCpf(string cpf)
        {
            using (var client = new HttpClient())
            {
                var url = String.Format("http://177.105.34.182:5002/api/Customer/GetClientePorCpf?cpf={0}", cpf);
                var tokenServiceResponse = await client.GetAsync(url);
                var responseString = await tokenServiceResponse.Content.ReadAsStringAsync();

                var responseCode = tokenServiceResponse.StatusCode;
                var responseMsg = new HttpResponseMessage(responseCode)
                {
                    Content = new StringContent(responseString, Encoding.UTF8, "application/json")
                };

                return View();
            }
        }


        public async Task<IActionResult> Delete(string cpf)
        {
            using (var client = new HttpClient())
            {
                var url = String.Format("http://177.105.34.182:5002/api/Customer/Delete?cpf={0}", cpf);
                var tokenServiceResponse = await client.GetAsync(url);
                var responseString = await tokenServiceResponse.Content.ReadAsStringAsync();

                var responseCode = tokenServiceResponse.StatusCode;
                var responseMsg = new HttpResponseMessage(responseCode)
                {
                    Content = new StringContent(responseString, Encoding.UTF8, "application/json")
                };

                return View();
            }
        }
    }
}