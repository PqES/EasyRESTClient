using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroServiceNet;
using Service;

namespace SolutionBEST.Controllers
{
    [Route("/")]
    public class MsProductController : Controller
    {
        private IMsProductService _productService;
        public MsProductController(IMsProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<string> Index()
        {
            var requestParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", "Elena"),
                new KeyValuePair<string, string>("password", "mest")
            };

            var a = _productService.GetAll();

            return "";
        }
    }
}