using Core.Endpoints.Products.models;
using Core.Utils;
using Core.Utils.models;

namespace Core.Endpoints.Products
{
    public class ProductController
    {

        private static readonly string _uri = "objects";

        public static async Task<Response> GetProductById(string productId)
        {
            string uri = $"{_uri}/{productId}";
            Console.WriteLine(uri);
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
            string payload = JsonParser.SerializeJson(product);
            return await HttpClientImpl.HttpPost(uri,payload);

        }


        public static async Task<Response> UpdateProductById(string productId,Product product)
        {
            string uri = $"{_uri}/{productId}";
            return await HttpClientImpl.HttpPut(uri,product);
        }


        public static async Task<Response> DeleteProductById(string productId)
        {
            string uri = $"{_uri}/{productId}";
            Console.WriteLine(uri);
            return await HttpClientImpl.HttpDelete(uri);
        }

    }
}

