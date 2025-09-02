using Core.Configs;
using Core.Utils.models;
using RestSharp;
using System.Reflection.PortableExecutable;

namespace Core.Utils
{
    public class HttpClientImpl
    {

        private static readonly RestClientOptions options = new(ApplicationConfigs.BASE_URL);
        private static readonly RestClient client = new(options);


        private static Response ExtractResponse(RestResponse response)
        {
            IReadOnlyCollection<HeaderParameter>? headers = null;
            string? content = "";

            if (response.Content != null)
            {
                content = response.Content;
                headers = response.Headers;

            }

            return new Response(content, (int)response.StatusCode, headers, response.IsSuccessful);

        }

        public static async Task<Response> HttpGet(string url)

        {
            RestRequest restRequest = new(url);
            RestResponse response = await client.GetAsync(restRequest);
            return ExtractResponse(response);

        }
    }
}
