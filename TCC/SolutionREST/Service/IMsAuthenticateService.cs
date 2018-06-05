namespace Service
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using MicroServiceNet;
    using MicroServiceNet.Attributes;

    [MicroServiceHost("MSAUTHENTICATE")]
    public interface IMsAuthenticateService : IMicroService
    {
        [MicroService("Authenticate", TypeRequest.Post)]
        Task<HttpResponseMessage> MsAuthenticate(List<KeyValuePair<string, string>> parameters = null);
    }
}