using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace MsCustomer.msCustomer
{
    public class InvocationServiceCEP
    {
        public string getCep()
        {
            string getCustomer = "https://viacep.com.br/ws/37160000/json/";
            try
            {
                var requisicaoWeb = WebRequest.CreateHttp(getCustomer);
                requisicaoWeb.Method = "GET";

                string result;

                using (var resposta = requisicaoWeb.GetResponse())
                {
                    var streamDados = resposta.GetResponseStream();
                    StreamReader reader = new StreamReader(streamDados);
                    result = reader.ReadToEnd().ToString();
                    streamDados.Close();
                    resposta.Close();
                }

                return result;

            }
            catch (Exception e)
            {
                return "Erro:" + e.Message;
            }
        }
    }
}
