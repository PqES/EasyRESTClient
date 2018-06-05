namespace Service
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using MicroServiceNet;

    [MicroServiceHost("MSCUSTOMER")]
    public interface IMsCustumerService : IMicroService
    {
        [MicroService("AddCustomer", TypeRequest.Post)]
        Task<HttpResponseMessage> AddCustomer(List<KeyValuePair<string, string>> parameters = null);
        [MicroService("GetAllClientes", TypeRequest.Get)]
        Task<HttpResponseMessage> GetAllClientes(List<KeyValuePair<string, string>> parameters = null);
        [MicroService("", TypeRequest.Get)]
        Task<HttpResponseMessage> GetClientePorCpf(List<KeyValuePair<string, string>> parameters = null);
        [MicroService("", TypeRequest.Get)]
        Task<HttpResponseMessage> Delete(List<KeyValuePair<string, string>> parameters = null);
    }
}