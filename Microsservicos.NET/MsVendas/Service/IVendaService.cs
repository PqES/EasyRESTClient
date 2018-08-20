namespace Service
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using MicroServiceNet;

    [MicroServiceHost("http://177.105.34.182:5004/api/Product/")]
    public interface IVendaService : IMicroService
    {
        [MicroService("UpdateStock", TypeRequest.Post)]
        Task<HttpResponseMessage> AddProductAsync(List<KeyValuePair<string, string>> parameters = null);
    }
}