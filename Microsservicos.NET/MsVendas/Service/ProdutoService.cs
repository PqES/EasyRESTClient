namespace Service
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using MicroServiceNet;
    using Microsoft.Extensions.Logging;
    using Pivotal.Discovery.Client;

    public class ProdutoService : MicroService<ProdutoService>, IProdutoService
    {
        public ProdutoService(IDiscoveryClient client, ILoggerFactory logFactory): base(client, logFactory) { }
        public Task<HttpResponseMessage> GetAll(List<KeyValuePair<string, string>> parameters = null)
        {
            return Execute(GetAll, parameters);
        }

        public Task<HttpResponseMessage> AddProduct(List<KeyValuePair<string, string>> parameters = null)
        {
            return Execute(AddProduct, parameters);
        }

        public Task<HttpResponseMessage> AddProduct(List<KeyValuePair<string, string>> parameters = null)
        {
            return Execute(AddProduct, parameters);
        }
    }
}