using System.Text.Json.Serialization;

namespace Core.Endpoints.Products.models
{
    public class ErrorResponse
    {
        [JsonPropertyName("error")]
        public string? Error { get; set; }
    }
}
