using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MicroServiceNet.Attributes;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
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
                    Task<HttpResponseMessage> result = null;
                    var client = new HttpClient(_handler, false);


                    var response = client.GetStringAsync("http://localhost:8761/eureka/apps/" + MicroServiceHostAttribute.GetMicroService(interfaces[i]).ToUpper()).Result;

                    System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
                    xDoc.LoadXml(response);

                    string hostname = xDoc.GetElementsByTagName("hostName")[0].InnerText;
                    string port = xDoc.GetElementsByTagName("port")[0].InnerText;

                    Uri myUri = new Uri($"http://{hostname}:{port}/{microServico.Name}");

                    var action = microServico.Action;

                    FormUrlEncodedContent encodedContent = null;
                    if (parameters != null && parameters.Count > 0)
                    {
                        encodedContent = new FormUrlEncodedContent(parameters);
                    }

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
