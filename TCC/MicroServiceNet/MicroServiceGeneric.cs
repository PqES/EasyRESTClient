using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Pivotal.Discovery.Client;

namespace MicroServiceNet
{
    public class MicroService<T>
    {
        private DiscoveryHttpClientHandler _handler;
        private ILogger<T> _logger;


        public MicroService(IDiscoveryClient client, ILoggerFactory logFactory)
        {
            _handler = new DiscoveryHttpClientHandler(client, logFactory.CreateLogger<DiscoveryHttpClientHandler>());
            _logger = logFactory.CreateLogger<T>();
        }


        public Task<HttpResponseMessage> Execute(
            Func<List<KeyValuePair<string, string>>, Task<HttpResponseMessage>> method,
            List<KeyValuePair<string, string>> parameters = null)
        {
            if (method.Method.DeclaringType != null)
            {
                var interfaces = method.Method.DeclaringType.GetInterfaces();
                for (int i = 0; i < interfaces.Length; i++)
                {
                    var microServico =
                        MicroServiceAttribute.GetMicroService(interfaces[i].GetMethod(method.Method.Name));

                    Uri myUri = new Uri(new Uri(MicroServiceHostAttribute.GetMicroService(interfaces[i])), microServico.Name);

                    var action = microServico.Action;

                    FormUrlEncodedContent encodedContent = null;
                    if (parameters != null && parameters.Count > 0)
                    {
                        encodedContent = new FormUrlEncodedContent(parameters);
                    }


                    Task<HttpResponseMessage> result = null;
                    var client = new HttpClient(_handler, false);

                    switch (action)
                    {
                        case TypeRequest.Get:
                            result = client.GetAsync(myUri);
                            break;
                        case TypeRequest.Post:
                            result = client.PostAsync(myUri, encodedContent);
                            break;
                        case TypeRequest.Put:
                            result = client.PutAsync(myUri, encodedContent);
                            break;
                        case TypeRequest.Delete:
                            result = client.DeleteAsync(myUri);
                            break;
                    }

                    return result;
                }
            }

            return null;
        }
    }
}
