using Core.Endpoints.Product.models;
using Core.Utils;
using Core.Utils.models;

namespace Core.Endpoints.Product
{
    public class ProductController
    {

        private static readonly string _uri = "/objects";

        public static async Task<Response> GetProductById(string productId)
        {
            string uri = $"{_uri}/{productId}";
            return await HttpClientImpl.HttpGet(uri);
        }


        public static async Task<Response> GetProducts()
        {
            string uri = $"{_uri}";
            return await HttpClientImpl.HttpGet(uri);
        }
    }
}

