namespace Service
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using MicroServiceNet;
    using Microsoft.Extensions.Logging;
    using Pivotal.Discovery.Client;

    public class MsNewsletterService : MicroService<MsNewsletterService>, IMsNewsletterService
    {
        public MsNewsletterService(IDiscoveryClient client, ILoggerFactory logFactory): base(client, logFactory) { }
        public Task<HttpResponseMessage> Subscribe(List<KeyValuePair<string, string>> parameters = null)
        {
            return Execute(Subscribe, parameters);
        }

        public Task<HttpResponseMessage> Publish(List<KeyValuePair<string, string>> parameters = null)
        {
            return Execute(Publish, parameters);
        }
    }
}