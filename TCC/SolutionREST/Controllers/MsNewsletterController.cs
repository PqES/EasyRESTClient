using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SolutionREST.Controllers
{
    public class MsNewsletterController : Controller
    {
        public async Task<IActionResult> Subscribe()
        {
            using (var client = new HttpClient())
            {

                var requestParams = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("cpf", "420.618.058-09"),
                    new KeyValuePair<string, string>("email", "gui_ramos@live.com")
                };

                var requestParamsFormUrlEncoded = new FormUrlEncodedContent(requestParams);
                var tokenServiceResponse = await client.PostAsync("http://177.105.34.182:5003/api/Newsletter/Subscribe", requestParamsFormUrlEncoded);
                var responseString = await tokenServiceResponse.Content.ReadAsStringAsync();

                var responseCode = tokenServiceResponse.StatusCode;
                var responseMsg = new HttpResponseMessage(responseCode)
                {
                    Content = new StringContent(responseString, Encoding.UTF8, "application/json")
                };

                return View();
            }
        }


        public async Task<IActionResult> Publish()
        {
            using (var client = new HttpClient())
            {;
                var tokenServiceResponse = await client.PostAsync("http://177.105.34.182:5003/api/Newsletter/Publish", null);
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