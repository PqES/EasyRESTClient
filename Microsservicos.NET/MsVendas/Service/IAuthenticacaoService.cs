namespace Service
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using MicroServiceNet;

    [MicroServiceHost("http://177.105.34.182:5001/api/")]
    public interface IAuthenticacaoService : IMicroService
    {
        [MicroService("Authenticate", TypeRequest.Post)]
        Task<HttpResponseMessage> Autenticar(List<KeyValuePair<string, string>> parameters = null);
    }
}