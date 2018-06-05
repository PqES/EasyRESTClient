using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SolutionREST.Controllers
{
    public class MsCustumerController : Controller
    {
        public async Task<IActionResult> AddCustomer()
        {
            using (var client = new HttpClient())
            {

                var requestParams = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("name", "Guilherme Ramos"),
                    new KeyValuePair<string, string>("cpf", "420.618.058-09"),
                    new KeyValuePair<string, string>("email", "gui_ramos@live.com")
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


        public async Task<IActionResult> GetClientePorCpf()
        {
            using (var client = new HttpClient())
            {
                var url = String.Format("http://177.105.34.182:5002/api/Customer/GetClientePorCpf?cpf={0}", "420.618.058-09");
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


        public async Task<IActionResult> Delete()
        {
            using (var client = new HttpClient())
            {
                var url = String.Format("http://177.105.34.182:5002/api/Customer/Delete?cpf={0}", "420.618.058-09");
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