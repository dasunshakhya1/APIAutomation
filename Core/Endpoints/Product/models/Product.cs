using System;
using System.Text.Json.Serialization;

namespace Core.Endpoints.Product.models
{
    public class Product
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("data")]
        public ProductData Data { get; set; }
    }
}
