namespace Service
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using MicroServiceNet;
    using Microsoft.Extensions.Logging;
    using Pivotal.Discovery.Client;

    public class MsCustumerService : MicroService<MsCustumerService>, IMsCustumerService
    {
        public MsCustumerService(IDiscoveryClient client, ILoggerFactory logFactory): base(client, logFactory) { }
        public Task<HttpResponseMessage> AddCustomer(List<KeyValuePair<string, string>> parameters = null)
        {
            return Execute(AddCustomer, parameters);
        }

        public Task<HttpResponseMessage> GetAllClientes(List<KeyValuePair<string, string>> parameters = null)
        {
            return Execute(GetAllClientes, parameters);
        }

        public Task<HttpResponseMessage> GetClientePorCpf(List<KeyValuePair<string, string>> parameters = null)
        {
            return Execute(GetClientePorCpf, parameters);
        }

        public Task<HttpResponseMessage> Delete(List<KeyValuePair<string, string>> parameters = null)
        {
            return Execute(Delete, parameters);
        }
    }
}