namespace Service
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using MicroServiceNet;
    using Microsoft.Extensions.Logging;
    using Pivotal.Discovery.Client;

    public class AuthenticacaoService : MicroService<AuthenticacaoService>, IAuthenticacaoService
    {
        public AuthenticacaoService(IDiscoveryClient client, ILoggerFactory logFactory): base(client, logFactory) { }
        public Task<HttpResponseMessage> Autenticar(List<KeyValuePair<string, string>> parameters = null)
        {
            return Execute(Autenticar, parameters);
        }
    }
}