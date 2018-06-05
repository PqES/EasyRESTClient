namespace Service
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using MicroServiceNet;
    using Microsoft.Extensions.Logging;
    using Pivotal.Discovery.Client;

    public class MsAuthenticateService : MicroService<MsAuthenticateService>, IMsAuthenticateService
    {
        public MsAuthenticateService(IDiscoveryClient client, ILoggerFactory logFactory): base(client, logFactory) { }
        public Task<HttpResponseMessage> MsAuthenticate(List<KeyValuePair<string, string>> parameters = null)
        {
            return Execute(MsAuthenticate, parameters);
        }
    }
}