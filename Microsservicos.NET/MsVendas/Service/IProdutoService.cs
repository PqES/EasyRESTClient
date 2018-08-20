namespace Service
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using MicroServiceNet;

    [MicroServiceHost("http://177.105.34.182:5003/api/Newsletter/")]
    public interface IProdutoService : IMicroService
    {
        [MicroService("GetAllProducts", TypeRequest.Get)]
        Task<HttpResponseMessage> GetAll(List<KeyValuePair<string, string>> parameters = null);
        [MicroService("Publish", TypeRequest.Post)]
        Task<HttpResponseMessage> AddProduct(List<KeyValuePair<string, string>> parameters = null);
        [MicroService("Publish", TypeRequest.Post)]
        Task<HttpResponseMessage> AddProduct(List<KeyValuePair<string, string>> parameters = null);
    }
}