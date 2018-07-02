namespace Service
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using MicroServiceNet;
    using Microsoft.Extensions.Logging;
    using Pivotal.Discovery.Client;

    public class VendaService : MicroService<VendaService>, IVendaService
    {
        public VendaService(IDiscoveryClient client, ILoggerFactory logFactory): base(client, logFactory) { }
        public Task<HttpResponseMessage> AddProductAsync(List<KeyValuePair<string, string>> parameters = null)
        {
            return Execute(AddProductAsync, parameters);
        }
    }
}