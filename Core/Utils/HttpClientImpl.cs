using Core.Configs;
using Core.Utils.models;
using RestSharp;

namespace Core.Utils
{
    public class HttpClientImpl
    {

        private static readonly RestClientOptions options = new(ApplicationConfigs.BASE_URL);
        private static readonly RestClient client = new(options);


        private static Response ExtractResponse(RestResponse response)
        {
            IReadOnlyCollection<HeaderParameter>? headers = null;
            string? content = null;

            if (response.Content != null)
            {
                content = response.Content;
                headers = response.Headers;

            }

            return new Response(content, (int)response.StatusCode, headers, response.IsSuccessful);

        }

        public static async Task<Response> HttpGet(string url)

        {
            RestRequest restRequest = new(url, Method.Get);
            RestResponse response = await client.GetAsync(restRequest);
            return ExtractResponse(response);

        }

        public static async Task<Response> HttpPost(string url, object payload)

        {

          
            RestRequest restRequest = new(url, Method.Post);
            restRequest.AddJsonBody(payload);
            var bodyParameter = restRequest.Parameters.FirstOrDefault(p => p.Type == ParameterType.RequestBody);

            Console.WriteLine(bodyParameter.ToString());

            RestResponse response = await client.PostAsync(restRequest);
          
            return ExtractResponse(response);

        }
    }
}
