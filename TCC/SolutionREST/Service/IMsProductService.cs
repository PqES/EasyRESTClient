namespace Service
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using MicroServiceNet;

    [MicroServiceHost("MSPRODUCT")]
    public interface IMsProductService : IMicroService
    {
        [MicroService("GetAllProducts", TypeRequest.Get)]
        Task<HttpResponseMessage> GetAll(List<KeyValuePair<string, string>> parameters = null);
    }
}