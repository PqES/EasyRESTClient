using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MsVendas.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAll()
        {
            using (var client = new HttpClient())
            {
                var tokenServiceResponse = await client.GetAsync("http://177.105.34.182:5004/api/Product/GetAllProducts");
                var responseString = await tokenServiceResponse.Content.ReadAsStringAsync();

                var responseCode = tokenServiceResponse.StatusCode;
                var responseMsg = new HttpResponseMessage(responseCode)
                {
                    Content = new StringContent(responseString, Encoding.UTF8, "application/json")
                };

                return View();
            }
        }

        public async Task<IActionResult> AddProduct(string name, string description, int number, double value)
        {
            using (var client = new HttpClient())
            {
                var requestParams = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("name", name),
                    new KeyValuePair<string, string>("cpf", description),
                    new KeyValuePair<string, string>("number", number.ToString()),
                    new KeyValuePair<string, string>("value", value.ToString())
                };

                var requestParamsFormUrlEncoded = new FormUrlEncodedContent(requestParams);
                var tokenServiceResponse = await client.PostAsync("http://177.105.34.182:5004/api/Product/AddProduct", requestParamsFormUrlEncoded);
                var responseString = await tokenServiceResponse.Content.ReadAsStringAsync();

                var responseCode = tokenServiceResponse.StatusCode;
                var responseMsg = new HttpResponseMessage(responseCode)
                {
                    Content = new StringContent(responseString, Encoding.UTF8, "application/json")
                };

                var tokenServiceResponseNotificacao = await client.PostAsync("http://177.105.34.182:5003/api/Newsletter/Publish", null);
                var responseStringNotificacao = await tokenServiceResponse.Content.ReadAsStringAsync();

                var responseCodeNotificacao = tokenServiceResponse.StatusCode;
                var responseMsgNotificacao = new HttpResponseMessage(responseCode)
                {
                    Content = new StringContent(responseString, Encoding.UTF8, "application/json")
                };


                return View();
            }
        }

    }
}