using Core.Endpoints.Products.models;
using Core.Utils;
using Core.Utils.models;

namespace Core.Endpoints.Products
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


        public static async Task<Response> AddProduct(Product product)
        {
            string uri = $"{_uri}";

            string payload = "{\"name\": \"Apple MacBook Pro 16\",\"data\": {\"year\": 2019,\"price\": 1849.99,\"CPU model\": \"Intel Core i9\",\"Hard disk size\": \"1 TB\"}}";
            return await HttpClientImpl.HttpPost(uri,product);

        }
    }
}

