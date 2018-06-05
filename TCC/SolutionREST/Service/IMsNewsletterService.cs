namespace Service
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using MicroServiceNet;

    [MicroServiceHost("MSNEWSLETTER")]
    public interface IMsNewsletterService : IMicroService
    {
        [MicroService("Subscribe", TypeRequest.Post)]
        Task<HttpResponseMessage> Subscribe(List<KeyValuePair<string, string>> parameters = null);
        [MicroService("Publish", TypeRequest.Post)]
        Task<HttpResponseMessage> Publish(List<KeyValuePair<string, string>> parameters = null);
    }
}