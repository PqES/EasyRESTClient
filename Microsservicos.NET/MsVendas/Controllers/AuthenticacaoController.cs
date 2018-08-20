using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MsVendas.Controllers
{
    public class AuthenticacaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Autenticar(string username, string password)
        {
            var client = new HttpClient();

            var requestParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            };

            var requestParamsFormUrlEncoded = new FormUrlEncodedContent(requestParams);
            var tokenServiceResponse = await client.PostAsync("http://177.105.34.182:5001/api/Authenticate", requestParamsFormUrlEncoded);
            string responseString = await tokenServiceResponse.Content.ReadAsStringAsync();

            var responseCode = tokenServiceResponse.StatusCode;
            var responseMsg = new HttpResponseMessage(responseCode)
            {
                Content = new StringContent(responseString, Encoding.UTF8, "application/json")
            };

            return View();
        }
    }
}