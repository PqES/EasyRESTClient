namespace Service
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using MicroServiceNet;

    [MicroServiceHost("http://177.105.34.182:5002/api/Customer/")]
    public interface IClienteService : IMicroService
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