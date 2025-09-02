using Core.Configs;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utils
{
    public class HttpClientImpl
    {

        private static readonly RestClientOptions options = new(ApplicationConfigs.BASE_URL);
        private static readonly RestClient client = new(options);




        public static async void HttpGet(string url)

        {
            RestRequest restRequest = new(url);
            RestResponse response = await client.GetAsync(restRequest);
            string? content = response.Content;
            Console.WriteLine(content);

        }
    }
}
